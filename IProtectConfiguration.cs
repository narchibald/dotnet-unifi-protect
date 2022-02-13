namespace UniFi.Protect.Api;

public interface IProtectConfiguration
{
    Uri NvrAddress { get; }

    string Username { get; }

    string Password { get; }

    bool AllowUntrustedCerts { get; }
}
