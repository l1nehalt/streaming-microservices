using TrackService.Infrastructure;
using TrackService.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSqlite(builder.Configuration)
    .AddRepositories()
    .AddServices()
    .AddApiLayer()
    .AddStatisticClient(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();