using System.Net.Http.Json;

namespace TrackService.Application.Clients;

public class StatisticClient(HttpClient client)
{
    public async Task<List<int>> GetPopularTrackIds()
    {
        var result = await client.GetFromJsonAsync<List<int>>("api/statistics/popular");

        return result ?? new List<int>();
    }
}