using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models;

public class Course
{
    public Course()
    {
        this.Homeworks = new HashSet<Homework>();
        this.Resources = new HashSet<Resource>();
        this.StudentsCourses = new HashSet<StudentCourse>();
    }
    [Key]
    public int CourseId { get; set; }

    [MaxLength(80)]
    [DataType("nvarchar")]
    public string Name { get; set; } = null!;

    [DataType("nvarchar")]
    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Homework> Homeworks { get; set; }
    public virtual ICollection<Resource> Resources { get; set; }
    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
}
