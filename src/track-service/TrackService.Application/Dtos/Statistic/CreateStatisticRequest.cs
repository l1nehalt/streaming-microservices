namespace TrackService.Application.Dtos.Statistic;

public class CreateStatisticRequest
{
    public int TrackId { get; set; }
    
    public int PlayCount { get; set; }
}