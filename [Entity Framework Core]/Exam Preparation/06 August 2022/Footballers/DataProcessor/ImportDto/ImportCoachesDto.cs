using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto;

[XmlType("Coach")]
public class ImportCoachesDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(40)]
    [XmlElement("Name")]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement("Nationality")]
    public string Nationality { get; set; } = null!;

    [XmlArray("Footballers")]
    public ImportCoachFootballerDto[] Footballers { get; set; } = null!;
}
