namespace StatisticService.Domain.Entities;

public class Statistic
{
    public int Id { get; set; }
    
    public int TrackId { get; set; }
    
    public int PlayCount { get; set; }
}