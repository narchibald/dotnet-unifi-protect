namespace UniFi.Protect.Api;

using System.Net;

public interface ISharedCookieContainer
{
    CookieContainer Container { get; }

    void Clear();
}

internal class SharedCookieContainer : ISharedCookieContainer
{
    public CookieContainer Container { get; private set; } = new ();

    public void Clear() => Container = new CookieContainer();
}
