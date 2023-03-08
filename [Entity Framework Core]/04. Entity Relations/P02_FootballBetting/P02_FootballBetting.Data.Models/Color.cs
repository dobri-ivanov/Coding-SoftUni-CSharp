﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Color
{
    public Color()
    {
        this.PrimaryKitTeams = new HashSet<Team>();
        this.SecondaryKitTeams = new HashSet<Team>();
    }
    [Key]
    public int ColorId { get; set; }

    [Required]
    [MaxLength(10)]
    public string Name { get; set; }

    [InverseProperty("PrimaryKitColor")]
    public virtual ICollection<Team> PrimaryKitTeams { get; set; }
    [InverseProperty("SecondaryKitColor")]
    public virtual ICollection<Team> SecondaryKitTeams { get; set; }
}
