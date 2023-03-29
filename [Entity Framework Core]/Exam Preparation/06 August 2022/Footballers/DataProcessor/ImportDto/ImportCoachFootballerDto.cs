using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto;

[XmlType("Footballer")]
public class ImportCoachFootballerDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(40)]
    [XmlElement("Name")]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement("ContractStartDate")]
    public string ContractStartDate { get; set; } = null!;

    [Required]
    [XmlElement("ContractEndDate")]
    public string ContractEndDate { get; set; } = null!;

    [Required]
    [MinLength(0)]
    [MaxLength(4)]
    [XmlElement("BestSkillType")]
    public string BestSkillType { get; set; } = null!;

    [Required]
    [MinLength(0)]
    [MaxLength(3)]
    [XmlElement("PositionType")]
    public string PositionType { get; set; } = null!;

}
