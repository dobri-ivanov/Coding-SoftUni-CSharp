using Microsoft.EntityFrameworkCore;

namespace P02_FootballBetting.Data;

using Common;

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
	}
}