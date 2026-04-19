namespace TrackService.Application.Dtos;

public class CreateStatisticRequest
{
    public int TrackId { get; set; }
    
    public int PlayCount { get; set; }
}