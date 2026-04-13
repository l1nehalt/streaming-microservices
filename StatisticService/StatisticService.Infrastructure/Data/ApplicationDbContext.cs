using Microsoft.EntityFrameworkCore;
using StatisticService.Domain.Entities;

namespace StatisticService.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Statistic> Statistics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Statistic>().HasKey(pk => new
        {
            pk.TrackId,
            pk.PlayCount
        });
        
        modelBuilder.Entity<Statistic>()
            .HasData
            (new Statistic { PlayCount = 3131, TrackId = 3, },
            new Statistic { PlayCount = 33123, TrackId = 33 },
            new Statistic { PlayCount = 10931, TrackId = 49 },
            new Statistic { PlayCount = 5543, TrackId = 76 },
            new Statistic { PlayCount = 122, TrackId = 102 });
        
        base.OnModelCreating(modelBuilder);
    }
}