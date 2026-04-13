namespace StatisticService.Web;

public static class ApiExtensions
{
    public static IServiceCollection AddApiLayer(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        
        return services;
    }
}