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
}