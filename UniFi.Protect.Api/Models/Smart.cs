﻿namespace UniFi.Protect.Api.Models;

using Newtonsoft.Json;

public class Smart
{
    [JsonConstructor]
    public Smart(
        int today,
        int average,
        List<int> lastDays)
    {
        this.Today = today;
        this.Average = average;
        this.LastDays = lastDays;
    }

    public int Today { get; }

    public int Average { get; }

    public IReadOnlyList<int> LastDays { get; }
}