using StatisticService.Application.Dtos;
using StatisticService.Domain.Entities;

namespace StatisticService.Application.Interfaces;

public interface IStatisticService
{
    Task<List<Statistic>> GetPopular();
    
    Task Create(StatisticCreationDto statistic);
    
    Task IncreasePlayCount(StatisticIncreasingDto statistic);
}