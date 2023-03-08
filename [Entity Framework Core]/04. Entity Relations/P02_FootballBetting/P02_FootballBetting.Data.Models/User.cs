using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(36)]
    public string Username { get; set; }

    [Required]
    [MaxLength(120)]
    public string Password { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public decimal Balance { get; set; }
}
