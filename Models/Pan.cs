﻿namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Pan
{
    [JsonConstructor]
    public Pan(
        Steps steps,
        Degrees degrees)
    {
        this.Steps = steps;
        this.Degrees = degrees;
    }

    public Steps Steps { get; }

    public Degrees Degrees { get; }
}