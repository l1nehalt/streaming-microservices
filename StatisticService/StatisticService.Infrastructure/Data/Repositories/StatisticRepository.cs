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

    public async Task Create(Statistic statistic)
    {
        await dbContext.Statistics.AddAsync(statistic);
        await dbContext.SaveChangesAsync();
    }

    public async Task IncreasePlayCount(Statistic statistic)
    {
        await dbContext.Statistics
            .Where(x => x.TrackId == statistic.TrackId)
            .ExecuteUpdateAsync(s =>
                s.SetProperty(pc => pc.PlayCount, pc => pc.PlayCount + 1)); 
    }
}                                                           