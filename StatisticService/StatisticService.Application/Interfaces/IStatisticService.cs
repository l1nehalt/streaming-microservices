using StatisticService.Domain.Entities;

namespace StatisticService.Application.Interfaces;

public interface IStatisticService
{
    Task<List<Statistic>> GetPopular();
}