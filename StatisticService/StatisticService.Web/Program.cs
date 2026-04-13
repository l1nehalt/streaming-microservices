using StatisticService.Infrastructure;
using StatisticService.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSqlite(builder.Configuration)
    .AddRepositories()
    .AddServices()
    .AddApiLayer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();