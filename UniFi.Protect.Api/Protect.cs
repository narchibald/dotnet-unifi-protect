namespace UniFi.Protect.Api;

using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UniFi.Protect.Api.Models;

public class Protect : IProtect
{
    // How often, in seconds, should we refresh our Protect login credentials.
    private const int ProtectLoginRefreshInterval = 1800;
    private readonly IProtectConfiguration configuration;
    private readonly ISharedCookieContainer cookieContainer;
    private readonly ILogger<Protect> logger;
    private readonly HttpClient httpClient;
    private readonly Dictionary<string, object> headers = new ();
    private readonly List<ProductInfoHeaderValue> agent = new ();
    private readonly IWebSocket websocket;
    private Task? loginRefresh;
    private CancellationTokenSource? loginRefreshCancellationToken;
    private NvrBootstrap? bootstrap;
    private DateTimeOffset? lastLoggedTime;
    private bool automaticRefresh;
    private bool loggedIn;
    private bool isUniFiOs;
    private bool isAdminUser;

    public Protect(IProtectConfiguration configuration, ISharedCookieContainer cookieContainer, IWebSocket webSocket, ILogger<Protect> logger)
    {
        this.configuration = configuration;
        this.cookieContainer = cookieContainer;
        this.logger = logger;
        this.websocket = webSocket;
        this.websocket.Updated += OnWebsocketUpdated;

        var handler = new HttpClientHandler()
        {
            CookieContainer = cookieContainer.Container,
            SslProtocols =
#if NET6_0
                    System.Security.Authentication.SslProtocols.Tls13,
#else
                System.Security.Authentication.SslProtocols.Tls12,
#endif
        };

        if (this.configuration.AllowUntrustedCerts)
        {
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) => true;
        }

        this.httpClient = new (handler);

        ClearLoginCredentials();
    }

    public event Action<NvrUpdatePacket>? Updated;

    public string NvrName => this.bootstrap?.Nvr != null
        ? this.bootstrap.Nvr.Name + " [" + this.bootstrap.Nvr.Type + "]"
        : this.configuration.NvrAddress.Host;

    private Uri AuthUrl
    {
        get
        {
            UriBuilder builder = new (this.configuration.NvrAddress)
            {
                Path = "/api/auth" + (this.isUniFiOs ? "/login" : string.Empty),
            };

            if (!this.isUniFiOs)
            {
                builder.Port = 7443;
            }

            return builder.Uri;
        }
    }

    private Uri BootstrapUrl
    {
        get
        {
            UriBuilder builder = new (this.configuration.NvrAddress)
            {
                Path = $"{QueryPrefix}/bootstrap",
            };

            if (!this.isUniFiOs)
            {
                builder.Port = 7443;
            }

            return builder.Uri;
        }
    }

    private Uri CamerasUrl
    {
        get
        {
            UriBuilder builder = new (this.configuration.NvrAddress)
            {
                Path = $"{QueryPrefix}/cameras",
            };

            if (!this.isUniFiOs)
            {
                builder.Port = 7443;
            }

            return builder.Uri;
        }
    }

    private Uri WebsocketSystemUrl
    {
        get
        {
            if (!this.isUniFiOs)
            {
                throw new NotSupportedException();
            }

            UriBuilder builder = new (this.configuration.NvrAddress)
            {
                Scheme = "wss",
                Path = "/api/ws/system",
            };

            return builder.Uri;
        }
    }

    private Uri? SystemUrl
    {
        get
        {
            UriBuilder builder = new (this.configuration.NvrAddress)
            {
                Path = "/api/system",
            };

            return builder.Uri;
        }
    }

    private string QueryPrefix => (this.isUniFiOs ? "/proxy/protect/" : string.Empty) + "api";

    public async Task<bool> RefreshDevices()
    {
        // Refresh the configuration from the NVR.
        if (!this.automaticRefresh && !(await this.Bootstrap()))
        {
            return false;
        }

        return true;
    }

    public async Task<bool> Connect(bool autoRefresh = false)
    {
        if (!await LoginProtect())
        {
            return false;
        }

        if (autoRefresh)
        {
            RestartLoginRefresh();
            await this.Bootstrap();
            this.automaticRefresh = autoRefresh;
        }

        return true;
    }

    private void RestartLoginRefresh()
    {
        this.loginRefreshCancellationToken = new CancellationTokenSource();
        this.loginRefresh = Task.Delay(TimeSpan.FromSeconds(1800), loginRefreshCancellationToken.Token);
        this.loginRefresh.ContinueWith(async t =>
        {
            if (t.IsCompletedSuccessfully)
            {
                await this.Bootstrap();
                if (!this.loginRefreshCancellationToken.IsCancellationRequested)
                {
                    RestartLoginRefresh();
                }
            }
        });
    }

    private Uri GetWebsocketUpdatesUrl(params (string Key, string Value)[] parameters)
    {
        if (!this.isUniFiOs)
        {
            throw new NotSupportedException();
        }

        UriBuilder builder = new (this.configuration.NvrAddress)
        {
            Scheme = "wss",
            Path = "/proxy/protect/ws/updates",
            Query = parameters.Any() ? null : string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}")),
        };

        return builder.Uri;
    }

    private async Task<bool> Bootstrap()
    {
        if (!await LoginProtect())
        {
            return false;
        }

        using var requestMessage = AddHeaders(new HttpRequestMessage(HttpMethod.Get, this.BootstrapUrl));
        using var response = await this.httpClient.SendAsync(requestMessage);
        if (!response.IsSuccessStatusCode)
        {
            LogDebug("Unable to retrieve NVR configuration information from UniFi Protect. Will retry again later.");
            ClearLoginCredentials();
            return false;
        }

        NvrBootstrap? data;
        try
        {
            var json = await response.Content.ReadAsStringAsync();
            data = JsonConvert.DeserializeObject<NvrBootstrap>(json, new JsonSerializerSettings { TraceWriter = new DiagnosticsTraceWriter() });
        }
        catch (Exception)
        {
            LogDebug("Unable to parse response from UniFi Protect. Will retry again later.");
            data = null;
        }

        // No camera information returned.
        if (data?.Cameras is null)
        {
            LogDebug("Unable to retrieve camera information from UniFi Protect. Will retry again later.");

            // Clear out our login credentials and reset for another try.
            ClearLoginCredentials();
            return false;
        }

        // On launch, let the user know we made it.
        var firstRun = this.bootstrap is null;
        this.bootstrap = data;

        if (firstRun)
        {
            LogInformation($"Connected to the Protect controller API (address: {data.Nvr.Host} mac: {data.Nvr.Mac}).");
        }

        CheckAdminUserStatus(firstRun);

        // We're good. Now connect to the event listener API if we're a UniFi OS device, otherwise, we're done.
        return await LaunchUpdatesListener();
    }

    // Connect to the UniFi OS realtime update events API.
    private async Task<bool> LaunchUpdatesListener()
    {
        if (!this.isUniFiOs)
        {
            return true;
        }

        // Log us in if needed.
        if (!await LoginProtect())
        {
            return false;
        }

        // If we already have a listener, we're already all set.
        if (this.websocket.IsConnected)
        {
            return true;
        }

        var updateUri = GetWebsocketUpdatesUrl(("lastUpdateId", this.bootstrap?.LastUpdateId ?? string.Empty));

        LogDebug($"Update listener: {updateUri}");

        if (!await this.websocket.Connect(updateUri))
        {
            LogError($"Error connecting to the realtime update events API");
        }

        return true;
    }

    // Check admin privileges.
    private bool CheckAdminUserStatus(bool firstRun = false)
    {
        if (!(this.bootstrap?.Users.Any() ?? false))
        {
            return false;
        }

        // Save our prior state so we can detect role changes without having to restart.
        var oldAdminStatus = this.isAdminUser;

        // Find this user.
        var user = this.bootstrap?.Users.FirstOrDefault(u => u.Id == this.bootstrap?.AuthUserId);

        if (!(user?.AllPermissions.Any() ?? false))
        {
            return false;
        }

        // Let's figure out this user's permissions.
        var newAdminStatus = false;
        foreach (var entry in user.AllPermissions)
        {
            // Each permission line exists as: permissiontype:permissions:scope.
            var permType = entry.Split(":");

            // We only care about camera permissions.
            if (permType[0] != "camera")
            {
                continue;
            }

            // Get the individual permissions.
            var permissions = permType[1].Split(",");

            // We found our administrative privileges - we're done.
            if (permissions.Contains("write"))
            {
                newAdminStatus = true;
                break;
            }
        }

        this.isAdminUser = newAdminStatus;

        // Only admin users can activate RTSP streams. Inform the user on startup, or if we detect a role change.
        if (firstRun && !this.isAdminUser)
        {
            LogInformation(
                $"The user '{this.configuration.Username}' requires the Administrator role in order to automatically configure camera RTSP streams.");
        }
        else if (!firstRun && (oldAdminStatus != this.isAdminUser))
        {
            LogInformation(
                $"Detected a role change for user '{this.configuration.Username}': the Administrator role has been {(this.isAdminUser ? "enabled" : "disabled")}.");
        }

        return true;
    }

    private async Task<bool> LoginProtect()
    {
        if (this.loggedIn)
        {
            return true;
        }

        // Is it time to renew our credentials?
        var now = DateTimeOffset.Now;
        if (lastLoggedTime.HasValue && now > (this.lastLoggedTime + TimeSpan.FromSeconds(ProtectLoginRefreshInterval)))
        {
            this.loggedIn = false;
            this.headers.Clear();
        }

        // Make sure we have a token, or get one if needed.
        if (!await AcquireToken())
        {
            return false;
        }

        // Log us in.
        var body = new { username = this.configuration.Username, password = this.configuration.Password };
        var json = JsonConvert.SerializeObject(body);
        using var requestMessage = AddHeaders(new HttpRequestMessage(HttpMethod.Post, this.AuthUrl));
        requestMessage.Content = new StringContent(json, null, "application/json");
        using var response = await this.httpClient.SendAsync(requestMessage);

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        // We're logged in.
        this.loggedIn = true;
        this.lastLoggedTime = now;

        // We're a UniFi OS device. Configure headers accordingly.
        var csrfToken = response.Headers.GetValues("X-CSRF-Token").FirstOrDefault();
        var cookie = response.Headers.GetValues("Set-Cookie").FirstOrDefault();

        if (!string.IsNullOrEmpty(csrfToken) && !string.IsNullOrEmpty(cookie) && this.headers.ContainsKey("X-CSRF-Token"))
        {
            // this.headers["Cookie"] = cookie;
            this.headers["X-CSRF-Token"] = csrfToken;
            return true;
        }

        // We're a UCK NVR device. Configure headers accordingly.
        var authToken = response.Headers.GetValues("Authorization").FirstOrDefault();

        if (!string.IsNullOrEmpty(authToken))
        {
            this.headers["Authorization"] = $"Bearer {authToken}";
            return true;
        }

        // Clear out our login credentials and reset for another try.
        ClearLoginCredentials();

        return false;
    }

    private async Task<bool> AcquireToken()
    {
        if (this.loggedIn || this.headers.ContainsKey("X-CSRF-Token") || this.headers.ContainsKey("Authorization"))
        {
            return true;
        }

        // UniFi OS has cross-site request forgery protection built into it's web management UI.
        // We use this fact to fingerprint it by connecting directly to the supplied NVR address
        // and see ifing there's a CSRF token waiting for us.
        using var requestMessage = AddHeaders(new HttpRequestMessage(HttpMethod.Get, this.SystemUrl));
        using var response = await this.httpClient.SendAsync(requestMessage);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        var csrfToken = response.Headers.GetValues("X-CSRF-Token")?.FirstOrDefault();
        if (!string.IsNullOrWhiteSpace(csrfToken))
        {
            this.isUniFiOs = true;
            headers["X-CSRF-Token"] = csrfToken;

            // UniFi OS has support for keepalive. Let's take advantage of that and reduce the workload on controllers.
            agent.Clear();
            agent.AddRange(new[]
            {
                new ProductInfoHeaderValue("rejectUnauthorized", "false"),
                new ProductInfoHeaderValue("keepAlive", "true"),
                new ProductInfoHeaderValue("maxSockets", 10.ToString()),
                new ProductInfoHeaderValue("maxFreeSockets", 5.ToString()),
                new ProductInfoHeaderValue("timeout", (60 * 1000).ToString()),
            });

            return true;
        }

        // If we don't have a token, the only option left for us is to look for a UniFi Cloud Key Gen2+ device.
        UriBuilder uriBuilder = new (this.configuration.NvrAddress)
        {
            Port = 7443,
        };

        using var otherRequestMessage = AddHeaders(new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri));
        using var otherResponse = await this.httpClient.SendAsync(otherRequestMessage);

        // If we're able to connect, we're good.
        if (otherResponse.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }

    private HttpRequestMessage AddHeaders(HttpRequestMessage request)
    {
        foreach (var header in this.headers)
        {
            request.Headers.Add(header.Key, header.Value.ToString());
        }

        // foreach (var header in this.agent)
        // request.Headers.UserAgent.Add(header);
        request.Version = new Version(2, 0);

        return request;
    }

    private void ClearLoginCredentials()
    {
        this.isAdminUser = false;
        this.isUniFiOs = false;
        this.loggedIn = false;
        this.lastLoggedTime = null;
        this.bootstrap = null;

        // Initialize the headers we need.
        this.headers.Clear();

        // We want the initial agent to be connection-agnostic, except for certificate validate since Protect uses self-signed certificates.
        // and we want to disable TLS validation, at a minimum. If we're UniFI OS though, we want to take advantage of the fact that it
        // supports keepalives to reduce workloads, but we deal with that elsewhere in acquireToken.
        this.agent.Clear();
        this.agent.Add(new ProductInfoHeaderValue("rejectUnauthorized", "false"));
    }

    private void OnWebsocketUpdated(NvrUpdatePacket obj) => Updated?.Invoke(obj);

    private void LogInformation(string message) => this.logger.LogInformation("{NvrName} : {Message}", NvrName, message);

    private void LogError(string message) => this.logger.LogError("{NvrName} : {Message}", NvrName, message);

    private void LogDebug(string message) => this.logger.LogDebug("{NvrName} : {Message}", NvrName, message);
}