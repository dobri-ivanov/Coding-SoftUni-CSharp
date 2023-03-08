﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Player
{
    [Key]
    public int PlayerId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public int SquadNumber { get; set; }

    [ForeignKey(nameof(Team))]
    public int? TeamId { get; set; }
    public virtual Team Team { get; set; }

    [ForeignKey(nameof(Position))]
    public int PositionId { get; set; }
    public virtual Position Position { get; set; }

    public bool IsInjured { get; set; }


    
}
