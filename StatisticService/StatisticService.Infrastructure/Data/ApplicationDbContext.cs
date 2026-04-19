using Microsoft.EntityFrameworkCore;
using StatisticService.Domain.Entities;

namespace StatisticService.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Statistic> Statistics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Statistic>()
            .HasKey(pk => pk.Id);
        
        modelBuilder.Entity<Statistic>()
            .HasData(
            new Statistic { Id = 1, PlayCount = 3131, TrackId = 3, },
            new Statistic { Id = 2, PlayCount = 33123, TrackId = 33 },
            new Statistic { Id = 3, PlayCount = 10931, TrackId = 49 },
            new Statistic { Id = 4, PlayCount = 5543, TrackId = 76 },
            new Statistic { Id = 5, PlayCount = 122, TrackId = 102 }
            );
        
        base.OnModelCreating(modelBuilder);
    }
}