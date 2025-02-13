using AutoMapper;
using Backend.Application.DTOs;
using Backend.Domain.Entities;

namespace Backend.Application.Mappers
{
    public class CountryMapperProfile : Profile
    {
        public CountryMapperProfile()
        {
            CreateMap<CountryDto, Country>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CountryName))
                .ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src.Cities.Select(c => new City
                {
                    CityId = c.CityId,
                    Name = c.CityName,
                    CountryId = src.CountryId
                })));
        }
    }
}
