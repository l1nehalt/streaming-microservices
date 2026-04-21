using StatisticService.Application.Dtos;
using StatisticService.Application.Interfaces;
using StatisticService.Domain.Abstractions;
using StatisticService.Domain.Entities;

namespace StatisticService.Application.Services;

public class StatisticService(IStatisticRepository statisticRepository) : IStatisticService
{
    public async Task<List<Statistic>> GetPopular()
    {
        var statistics = await statisticRepository.GetPopular();

        return statistics;
    }

    public async Task Create(StatisticCreationDto statisticDto)
    {
        var statistic = new Statistic
        {
            TrackId = statisticDto.TrackId,
            PlayCount = statisticDto.PlayCount,
        };
        
        await statisticRepository.Create(statistic);
    }

    public async Task IncreasePlayCount(StatisticIncreasingDto statisticDto)
    {
        var statistic = new Statistic
        {
            TrackId = statisticDto.TrackId
        };
        
        await statisticRepository.IncreasePlayCount(statistic);
    }
}