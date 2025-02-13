using Backend.Infrastructure.Data;
using Backend.Application.Mappers;
using Backend.Application.Interfaces;
using Backend.Application.Services;
using Backend.Infrastructure.Repositories;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Backend.Infrastructure.Data.Seeds;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PostgresConnection")
    )
    .UseSnakeCaseNamingConvention()
    .EnableSensitiveDataLogging()
    .LogTo(Console.WriteLine, LogLevel.Information)
);

builder.Services.AddAutoMapper(
    typeof(MuseumMapperProfile),
    typeof(CityMapperProfile),
    typeof(CountryMapperProfile),
    typeof(MuseumScheduleMapperProfile)
);

builder.Services.AddSingleton<IMuseumService, MuseumService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICityRepository, CityRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.SeedData();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
