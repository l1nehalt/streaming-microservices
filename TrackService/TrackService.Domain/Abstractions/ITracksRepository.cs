using TrackService.Domain.Entities;

namespace TrackService.Domain.Abstractions;

public interface ITracksRepository
{
    Task<List<Track>> GetAll();
    
    Task<Track?> GetById(int id);

    Task Create(Track track);
}