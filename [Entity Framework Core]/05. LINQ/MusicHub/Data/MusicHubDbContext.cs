﻿using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

namespace MusicHub.Data;

public class MusicHubDbContext : DbContext
{
    public MusicHubDbContext()
    {
    }

    public MusicHubDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Writer> Writers { get; set; } = null!;
    public DbSet<Song> Songs { get; set; } = null!;
    public DbSet<Album> Albums { get; set; } = null!;
    public DbSet<Producer> Producers { get; set; } = null!;
    public DbSet<Performer> Performers { get; set; } = null!;
    public DbSet<SongPerformer> SongsPerformers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(Configuration.ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<SongPerformer>()
            .HasKey(sp => new { sp.SongId, sp.PerformerId });
    }
}