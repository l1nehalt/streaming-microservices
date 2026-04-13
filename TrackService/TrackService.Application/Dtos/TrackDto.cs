namespace TrackService.Application.Dtos;

public class TrackDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int PlayCount { get; set; }
}

public class TrackCreationDto : TrackDto
{
    public int ArtistId { get; set; }
}