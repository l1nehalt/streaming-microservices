using Microsoft.EntityFrameworkCore;
using StatisticService.Domain.Abstractions;
using StatisticService.Domain.Entities;

namespace StatisticService.Infrastructure.Data.Repositories;

public class StatisticRepository(ApplicationDbContext dbContext) : IStatisticRepository
{
    public async Task<List<Statistic>> GetPopular()
    {
        return await dbContext.Statistics
            .OrderByDescending(x => x.PlayCount)
            .Take(5)
            .ToListAsync();
    }
}                                                           