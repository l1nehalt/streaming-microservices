using Microsoft.EntityFrameworkCore;
using TrackService.Domain.Abstractions;
using TrackService.Domain.Entities;

namespace TrackService.Infrastructure.Data.Repositories;

public class TracksRepository(ApplicationDbContext dbContext) : ITracksRepository
{
    public async Task<List<Track>> GetAll()
    {
        return await dbContext.Tracks.ToListAsync();
    }

    public async Task<Track?> GetById(int id)
    {
        return await dbContext.Tracks.FirstOrDefaultAsync(track => track.Id == id);
    }

    public async Task Create(Track track)
    {
        await dbContext.Tracks.AddAsync(track);
        await dbContext.SaveChangesAsync();
    }

    public Task<List<Track>> GetByIds(List<int> ids)
    {
        return dbContext.Tracks
            .Where(track => ids.Contains(track.Id))
            .ToListAsync();
    }
}