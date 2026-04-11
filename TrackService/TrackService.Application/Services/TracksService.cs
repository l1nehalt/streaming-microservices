using TrackService.Application.DTOs;
using TrackService.Application.Interfaces;
using TrackService.Domain.Abstractions;
using TrackService.Domain.Entities;

namespace TrackService.Application.Services;

public class TracksService(ITracksRepository tracksRepository) : ITracksService
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
}