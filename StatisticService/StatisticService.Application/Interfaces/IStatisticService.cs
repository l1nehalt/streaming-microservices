namespace StatisticService.Application.Interfaces;

public interface IStatisticService
{
    Task<List<int>> GetPopular();
}