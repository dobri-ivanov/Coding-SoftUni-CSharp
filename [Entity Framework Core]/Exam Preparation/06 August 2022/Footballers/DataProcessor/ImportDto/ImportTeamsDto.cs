using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto;

public class ImportTeamsDto
{
    [JsonProperty("Name")]
    //[RegularExpression(@"^[A-Za-z0-9\\s\\.\\-]{3,}$")]
    [MinLength(3)]
    [MaxLength(40)]
    [Required]
    public string Name { get; set; } = null!;

    [JsonProperty("Nationality")]
    [Required]
    [MinLength(2)]
    [MaxLength(40)]
    public string Nationality { get; set; } = null!;

    [JsonProperty("Trophies")]
    [Required]
    public int Trophies { get; set; }

    [JsonProperty("Footballers")]
    public int[] Footballers { get; set; } = null!;
}
