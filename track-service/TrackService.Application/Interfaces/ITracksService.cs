using TrackService.Application.Dtos;
using TrackService.Application.Dtos.Track;

namespace TrackService.Application.Interfaces;

public interface ITracksService
{
    Task<List<TrackDto>> GetAllAsync();

    Task<TrackDto> GetByIdAsync(int id);

    Task CreateAsync(TrackCreationDto trackDto);

    Task<List<TrackDto>> GetPopularAsync();

    Task PlayAsync(PlayTrackDto playTrackDto);
}