using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackService.Domain.Entities;

namespace TrackService.Infrastructure.Data.Configurations;

public class ArtistsConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.HasKey(b => b.Id);

        builder
            .HasMany(b => b.Tracks)
            .WithOne(a => a.Artist)
            .HasForeignKey(a => a.ArtistId);
    }
}