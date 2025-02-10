﻿using AutoMapper;
using Backend.Application.DTOs;
using Backend.Domain.Entities;

public class CityMapperProfile : Profile
{
    public CityMapperProfile()
    {
        CreateMap<City, CityDTO>()
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country != null ? src.Country.Name : "Unknown"));

        CreateMap<CityDTO, City>();
    }
}
