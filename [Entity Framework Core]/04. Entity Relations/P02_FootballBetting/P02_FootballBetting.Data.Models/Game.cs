using P02_FootballBetting.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data;

public class Game
{
    [Key]
    public int GameId { get; set; }

    [ForeignKey(nameof(HomeTeam))]
    public int HomeTeamId { get; set; }
    public virtual Team HomeTeam { get; set; }

    [ForeignKey(nameof(AwayTeam))]
    public int AwayTeamId { get; set; }
    public virtual Team AwayTeam { get; set; }
    public int HomeTeamGoals { get; set; }
    public int AwayTeamGoals { get; set; }
    public DateTime DateTime { get; set; }
    public double HomeTeamBetRate { get; set; }
    public double AwayTeamBetRate { get; set; }
    public double DrawBetRate { get; set; }
    [MaxLength(7)]
    public string? Result { get; set; }
}
