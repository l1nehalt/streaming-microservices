using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrackService.Infrastructure.Data;
using TrackService.Infrastructure.Repositories;
using TrackService.Application.Interfaces;
using TrackService.Application.Services;
using TrackService.Domain.Abstractions;

namespace TrackService.Infrastructure;

public static class DataExtensions
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
        services.AddScoped<ITracksRepository, TracksRepository>();
        
        return services;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITracksService, TracksService>();
        
        return services;
    }
}