using Backend.Infrastructure.Data;
using Backend.Infrastructure.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Application.Mappers;
using Backend.Application.Interfaces;
using Backend.Application.Services;
using Backend.Infrastructure.Repositories;
using Backend.Domain.Interfaces;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(MuseumMapperProfile).Assembly);
builder.Services.AddSingleton<IMuseumService, MuseumService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddAutoMapper(typeof(CityMapperProfile));

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
