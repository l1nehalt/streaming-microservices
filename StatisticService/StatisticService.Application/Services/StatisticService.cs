using StatisticService.Application.Interfaces;
using StatisticService.Domain.Abstractions;

namespace StatisticService.Application.Services;

public class StatisticService(IStatisticRepository statisticRepository) : IStatisticService
{
    public async Task<List<int>> GetPopular()
    {
        var statistics = await statisticRepository.GetPopular();
        
        return statistics.Select(x => x.TrackId).ToList();
    }
}