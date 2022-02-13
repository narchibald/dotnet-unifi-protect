namespace UniFi.Protect.Api.Extensions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUniFiProtectServices(this IServiceCollection services)
    {
        services.AddScoped<ISharedCookieContainer, SharedCookieContainer>();
        services.AddScoped<IWebSocket, WebSocket>();
        services.AddScoped<IProtect, Protect>();

        return services;
    }
}
