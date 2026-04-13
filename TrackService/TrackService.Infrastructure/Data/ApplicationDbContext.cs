using Microsoft.EntityFrameworkCore;
using TrackService.Domain.Entities;
using TrackService.Infrastructure.Data.Configurations;

namespace TrackService.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Artist> Artists { get; set; }
    
    public DbSet<Track> Tracks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TracksConfiguration());
        modelBuilder.ApplyConfiguration(new ArtistsConfiguration());

        modelBuilder.Entity<Artist>().HasData(
            new Artist { Id = 1, Description = "---", Name = "Cole Will" }
        );
        
        modelBuilder.Entity<Track>().HasData(
            new Track { Id = 33, Title = "Not You", Description = "---", ArtistId = 1 },
            new Track { Id = 49, Title = "Legendary", Description = "---", ArtistId = 1 },
            new Track { Id = 76, Title = "Мои клиенты", Description = "---", ArtistId = 1 },
            new Track { Id = 3, Title = "Holding On", Description = "---", ArtistId = 1 },
            new Track { Id = 102, Title = "Poppin", Description = "---", ArtistId = 1 }
        );
        
        base.OnModelCreating(modelBuilder);
    }
}

