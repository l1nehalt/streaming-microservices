using Microsoft.EntityFrameworkCore;
using TrackService.Domain.Entities;

namespace TrackService.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Artist> Artists { get; set; }
    
    public DbSet<Track> Tracks { get; set; }
}