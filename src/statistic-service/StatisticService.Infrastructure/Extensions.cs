using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StatisticService.Application.Interfaces;
using StatisticService.Application.Messaging;
using StatisticService.Domain.Abstractions;
using StatisticService.Infrastructure.Data;
using StatisticService.Infrastructure.Data.Repositories;

namespace StatisticService.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddSqlite(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });
        
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IStatisticRepository, StatisticRepository>();
        return services;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IStatisticService, Application.Services.StatisticService>();
        return services;
    }

    public static IServiceCollection AddRabbitMq(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<TrackPlayedConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost");
                cfg.ConfigureEndpoints(context);
            });
        });
        
        return services;
    }
}