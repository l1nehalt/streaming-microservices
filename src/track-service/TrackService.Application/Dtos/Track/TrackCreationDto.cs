namespace TrackService.Application.Dtos.Track;

public class TrackCreationDto
{
    public string Title { get; set; }

    public string Description { get; set; }
    
    public int ArtistId { get; set; }
}