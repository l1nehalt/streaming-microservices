using TrackService.Application.Clients;
using TrackService.Application.Dtos;
using TrackService.Application.Interfaces;
using TrackService.Domain.Abstractions;
using TrackService.Domain.Entities;

namespace TrackService.Application.Services;

public class TracksService(ITracksRepository tracksRepository, StatisticClient client) : ITracksService
{
    public async Task<List<TrackDto>> GetAllAsync()
    {
       var result = await tracksRepository.GetAll();
       
       return result.Select(t => new TrackDto
       {
           Id = t.Id,
           Title = t.Title,
           Description = t.Description
       }).ToList();
    }

    public async Task<TrackDto> GetByIdAsync(int id)
    {
        var result = await tracksRepository.GetById(id);

        return new TrackDto
        {
            Id = result.Id,
            Title = result.Title,
            Description = result.Description
        };
    }

    public async Task CreateAsync(TrackCreationDto trackDto)
    {
        var trackEntity = new Track
        {
            Title = trackDto.Title,
            Description = trackDto.Description,
            ArtistId = trackDto.ArtistId
        };
        
        await tracksRepository.Create(trackEntity);
    }

    public async Task<List<TrackDto>> GetPopular()
    {
        var popularIds = client.GetPopularTrackIds().Result;

        var tracks = await tracksRepository.GetByIds(popularIds);
        
        return tracks
            .OrderBy(x => popularIds.IndexOf(x.Id))
            .Select(x => new TrackDto
            {
                Id = x.Id,
                Description = x.Description,
                Title = x.Title
            }).ToList();
    }
}