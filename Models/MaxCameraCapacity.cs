namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class MaxCameraCapacity
{
    [JsonConstructor]
    public MaxCameraCapacity(
        int _4K,
        int _2K,
        int hd)
    {
        this._4K = _4K;
        this._2K = _2K;
        this.Hd = hd;
    }

    public int _4K { get; }

    public int _2K { get; }

    public int Hd { get; }
}