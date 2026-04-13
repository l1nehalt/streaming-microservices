using TrackService.Application.Clients;

namespace TrackService.Web;

public static class ApiExtensions
{
    public static IServiceCollection AddApiLayer(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        
        return services;
    }

    public static IServiceCollection AddStatisticClient(this IServiceCollection services, IConfiguration configuration)
    {
        var statisticsUrl = configuration["StatisticsUrl"];
        
        if (string.IsNullOrEmpty(statisticsUrl))
        {
            throw new Exception("StatisticsUrl is not configured!");
        }

        services.AddHttpClient<StatisticClient>(client =>
        {
            client.BaseAddress = new Uri(statisticsUrl);
        });
        
        return services;
    }
}