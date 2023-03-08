using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;

internal class Player
{
    [Key]
    public int PlayerId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public int SquadNumber { get; set; }
    public int? TeamId { get; set; }
    public int PositionId { get; set; }
    public bool IsInjured { get; set; }


    //TODO
}
