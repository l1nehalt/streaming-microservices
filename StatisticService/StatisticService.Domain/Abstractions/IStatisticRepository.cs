using StatisticService.Domain.Entities;

namespace StatisticService.Domain.Abstractions;

public interface IStatisticRepository
{
    Task<List<Statistic>> GetPopular();

    Task Create(Statistic statistic);

    Task IncreasePlayCount(Statistic statistic);
}