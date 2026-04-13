namespace TrackService.Application.Dtos;

public record TrackStatisticResponse(
    int TrackId,
    int PlayCount
);