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
        
        base.OnModelCreating(modelBuilder);
    }
}

