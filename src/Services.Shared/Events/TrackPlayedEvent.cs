namespace Shared.Events;

public record TrackPlayedEvent(int TrackId, DateTime PlayedAt);