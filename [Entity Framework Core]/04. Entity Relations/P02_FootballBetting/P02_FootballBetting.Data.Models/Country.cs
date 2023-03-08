﻿using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;

public class Country
{
    public Country()
    {
        this.Towns = new HashSet<Town>();
    }
    [Key]
    public int CountryId { get; set; }

    [Required]
    [MaxLength(60)]
    public string Name { get; set; }

    public virtual ICollection<Town> Towns { get; set; }
}
