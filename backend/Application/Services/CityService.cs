using AutoMapper;
using Backend.Application.DTOs;
using Backend.Application.Interfaces;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Infrastructure.Data.Repositories;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public CityService(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<CityDto> GetCityByIdAsync(int cityId)
    {
        var city = await _cityRepository.GetCityByIdAsync(cityId);
        if (city == null)
        {
            throw new Exception("City not found");
        }

        return _mapper.Map<CityDto>(city);
    }

    public async Task<IEnumerable<CityDto>> GetAllCitiesAsync()
    {
        var cities = await _cityRepository.GetAllCitiesAsync();
        return _mapper.Map<IEnumerable<CityDto>>(cities);
    }

    public async Task<CityDto> CreateCityAsync(CityDto cityDto)
    {
        var country = await _cityRepository.GetCountryByIdAsync(cityDto.CountryId);
        if (country == null)
        {
            throw new Exception("Country not found");
        }

        var city = _mapper.Map<City>(cityDto);
        city.Country = country;

        var createdCity = await _cityRepository.CreateCityAsync(city);
        if (createdCity == null)
        {
            throw new Exception("Failed to create city");
        }

        return _mapper.Map<CityDto>(createdCity);
    }

    public async Task<CityDto> UpdateCityAsync(int cityId, CityDto cityDto)
    {
        var city = await _cityRepository.GetCityByIdAsync(cityId);
        if (city == null)
        {
            throw new Exception("City not found");
        }

        _mapper.Map(cityDto, city);

        var updatedCity = await _cityRepository.UpdateCityAsync(city);
        if (updatedCity == null)
        {
            throw new Exception("Failed to update city");
        }

        return _mapper.Map<CityDto>(updatedCity);
    }

    public async Task<bool> DeleteCityAsync(int cityId)
    {
        return await _cityRepository.DeleteCityAsync(cityId);
    }
}
