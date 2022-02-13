using Newtonsoft.Json;

namespace UniFi.Protect.Api.Models;

public class State
{
    [JsonConstructor]
    public State(
        int pan,
        double tilt,
        double zoom,
        int panning,
        int tilting)
    {
        this.Pan = pan;
        this.Tilt = tilt;
        this.Zoom = zoom;
        this.Panning = panning;
        this.Tilting = tilting;
    }

    public int Pan { get; }

    public double Tilt { get; }

    public double Zoom { get; }

    public int Panning { get; }

    public int Tilting { get; }
}