using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Events;
using TrackService.Application.Clients;
using TrackService.Application.Dtos;
using TrackService.Application.Dtos.Statistic;
using TrackService.Application.Dtos.Track;
using TrackService.Application.Interfaces;
using TrackService.Domain.Abstractions;
using TrackService.Domain.Entities;

namespace TrackService.Application.Services;

public class TracksService(ITracksRepository tracksRepository, 
    StatisticClient client, IPublishEndpoint publishEndpoint, ILogger<Track> logger) : ITracksService
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

        try
        {
            await tracksRepository.Create(trackEntity);

            var newStatistic = new CreateStatisticRequest
            {
                PlayCount = 0,
                TrackId = trackEntity.Id
            };
            
            await client.CreateStatistic(newStatistic);
        }
        catch (Exception)
        {
            return;
        }
    }

    public async Task PlayAsync(PlayTrackDto playTrackDto)
    {
        await publishEndpoint.Publish(new TrackPlayedEvent(playTrackDto.TrackId, DateTime.UtcNow));
        
        logger.LogInformation($"Трек был прослушан в {DateTime.UtcNow}");
    }

    public async Task<List<TrackDto>> GetPopularAsync()
    {
        var stats = await client.GetPopularTrackStats();
        
        var ids = stats
            .Select(x => x.TrackId)
            .ToList();
        var tracks = await tracksRepository.GetByIds(ids);

        return tracks
            .OrderBy(x => ids.IndexOf(x.Id))
            .Select(x => new TrackDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                PlayCount = stats
                    .First(s => s.TrackId == x.Id)
                    .PlayCount
            }).ToList();
    }
}