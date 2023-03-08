using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models;

public class Student
{
    public Student()
    {
        this.Homeworks = new HashSet<Homework>();
        this.StudentsCourses = new HashSet<StudentCourse>();
    }
    [Key]
    public int StudentId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(10)]
    [DataType("varchar")]
    public string? PhoneNumber { get; set; } = null!;
    public DateTime RegisteredOn { get; set; }
    public DateTime? Birthday { get; set; }

    public virtual ICollection<Homework> Homeworks { get; set; }
    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }

}