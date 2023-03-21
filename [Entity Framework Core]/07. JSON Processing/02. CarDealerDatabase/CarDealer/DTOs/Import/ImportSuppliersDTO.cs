using Newtonsoft.Json;

namespace CarDealer.DTOs.Import;

public class ImportSuppliersDTO
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("isImporter")]
    public bool IsImporter { get; set; }
}
