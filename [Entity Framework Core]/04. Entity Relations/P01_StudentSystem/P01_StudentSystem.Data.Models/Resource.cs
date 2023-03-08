using P01_StudentSystem.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }

    [MaxLength(50)]
    [DataType("nvarchar")]
    public string Name { get; set; } = null!;

    [DataType("varchar")]
    public string Url { get; set; } = null!;
    public RecourceTypes RecourceType { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
}
