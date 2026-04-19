using System.Net;
using System.Net.Http.Json;
using TrackService.Application.Dtos;

namespace TrackService.Application.Clients;

public class StatisticClient(HttpClient client)
{
    public async Task<List<TrackStatisticResponse>> GetPopularTrackStats()
    {
        var result = await client
            .GetFromJsonAsync<List<TrackStatisticResponse>>("api/statistics/popular");
        
        return result ?? new List<TrackStatisticResponse>();
    }

    public async Task CreateStatistic(CreateStatisticRequest request)
    {
        var response = await client
            .PostAsJsonAsync("api/statistics", request);
        
        response.EnsureSuccessStatusCode();
    }

    public async Task IncreaseStatisticPlayCount(PlayTrackDto playTrackDto)
    {
        var response = await client
            .PutAsJsonAsync("api/statistics/increase-playcount", new { playTrackDto.TrackId });

        response.EnsureSuccessStatusCode();
    }
}