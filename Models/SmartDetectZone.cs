using Newtonsoft.Json;

namespace UniFi.Protect.Api.Models;

public class SmartDetectZone
{
    [JsonConstructor]
    public SmartDetectZone(
        int id,
        string name,
        string color,
        List<List<int>> points,
        int sensitivity,
        List<string> objectTypes)
    {
        this.Id = id;
        this.Name = name;
        this.Color = color;
        this.Points = points;
        this.Sensitivity = sensitivity;
        this.ObjectTypes = objectTypes;
    }

    public int Id { get; }

    public string Name { get; }

    public string Color { get; }

    public IReadOnlyList<List<int>> Points { get; }

    public int Sensitivity { get; }

    public IReadOnlyList<string> ObjectTypes { get; }
}