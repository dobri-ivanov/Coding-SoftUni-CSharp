using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatresDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; } = null!;

        [JsonProperty("NumberOfHalls")]
        [Required]
        [Range(1, 10)]
        public sbyte NumberOfHalls { get; set; }

        [JsonProperty("Director")]
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Director { get; set; } = null!;

        [JsonProperty("Tickets")]
        public ImportTheatreTicketsDto[] Tickets { get; set; } = null!;
    }
}
