
using WeatherApiJson.Middleware;
using WeatherApiJson.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<OpenWeatherSettings>(
    builder.Configuration.GetSection("OpenWeatherVault"));

builder.Services.AddControllers();

builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
