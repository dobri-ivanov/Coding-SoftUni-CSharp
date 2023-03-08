﻿using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data;

public class User
{
    public User()
    {
        this.Bets = new HashSet<Bet>();
    }
    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(36)]
    public string Username { get; set; } = null!;

    [Required]
    [MaxLength(120)]
    public string Password { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public decimal Balance { get; set; }

    public virtual ICollection<Bet> Bets { get; set; }
}
