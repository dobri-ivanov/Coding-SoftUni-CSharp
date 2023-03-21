﻿using Newtonsoft.Json;

namespace CarDealer.DTOs;

public class ImportCarsDTO
{

    [JsonProperty("make")]
    public string Make { get; set; } = null!;

    [JsonProperty("model")]
    public string Model { get; set; } = null!;

    [JsonProperty("traveledDistance")]
    public long TravelledDistance { get; set; }

    [JsonProperty("partsId")]
    public int[] PartsId { get; set; }
}