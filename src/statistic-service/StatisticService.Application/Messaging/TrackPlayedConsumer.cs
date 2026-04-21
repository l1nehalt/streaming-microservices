using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Events;
using StatisticService.Domain.Abstractions;
using StatisticService.Domain.Entities;

namespace StatisticService.Application.Messaging;

public class TrackPlayedConsumer(IStatisticRepository statisticRepository, 
    ILogger<Statistic> logger) : IConsumer<TrackPlayedEvent>
{
    public async Task Consume(ConsumeContext<TrackPlayedEvent> context)
    {
        var statistic = new Statistic
        {
            TrackId = context.Message.TrackId,
        };
        
        await statisticRepository.IncreasePlayCount(statistic);
        
        logger.LogInformation($"Трек с Id {context.Message.TrackId} был прослушан в {context.Message.PlayedAt}");
    }
}