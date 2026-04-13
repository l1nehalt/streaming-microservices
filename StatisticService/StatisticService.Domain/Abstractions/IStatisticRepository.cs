using StatisticService.Domain.Entities;

namespace StatisticService.Domain.Abstractions;

public interface IStatisticRepository
{
    Task<List<Statistic>> GetPopular();
}