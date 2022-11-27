namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class MotionZone
{
    [JsonConstructor]
    public MotionZone(
        int id,
        string name,
        string color,
        List<List<float>> points,
        int sensitivity)
    {
        this.Id = id;
        this.Name = name;
        this.Color = color;
        this.Points = points;
        this.Sensitivity = sensitivity;
    }

    public int Id { get; }

    public string Name { get; }

    public string Color { get; }

    public IReadOnlyList<List<float>> Points { get; }

    public int Sensitivity { get; }
}