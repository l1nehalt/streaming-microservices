using TrackService.Application.DTOs;

namespace TrackService.Application.Interfaces;

public interface ITracksService
{
    Task<List<TrackDto>> GetAllAsync();
    
    Task<TrackDto> GetByIdAsync(int id);
    
    Task CreateAsync(TrackCreationDto trackDto);
}