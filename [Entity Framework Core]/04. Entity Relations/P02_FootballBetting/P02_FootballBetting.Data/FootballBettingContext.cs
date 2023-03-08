using Microsoft.EntityFrameworkCore;

namespace P02_FootballBetting.Data;

using Common;
using P02_FootballBetting.Data.Models;

public class FootbalBettingContext : DbContext 
{
	public FootbalBettingContext()
	{

	}
	public FootbalBettingContext(DbContextOptions options) : base(options)
	{

	}
	//Connection
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
		}
	}
	//Fluent API
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<PlayerStatistic>(e =>
		{
			e.HasKey(ps => new { ps.GameId, ps.PlayerId });
		});
	}
}