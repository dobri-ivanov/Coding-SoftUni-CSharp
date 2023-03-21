using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ProductShop.DTOs.Import;

public class ImportProductsDTO
{
    [JsonProperty("Name")]
    public string Name { get; set; } = null!;
    [JsonProperty("Price")]
    public decimal Price { get; set; }
    [JsonProperty("SellerId")]
    public int SellerId { get; set; }
    [JsonProperty("BuyerId")]
    public int? BuyerId { get; set; }
}
