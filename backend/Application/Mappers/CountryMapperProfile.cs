using AutoMapper;
using Backend.Application.DTOs;
using Backend.Domain.Entities;

namespace Backend.Application.Mappers
{
    public class CountryMapperProfile : Profile
    {
        public CountryMapperProfile()
        {
            CreateMap<Country, CountryDTO>()
                .ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src.Cities!.Select(c => c.Name)));
            CreateMap<CountryDTO, Country>();
        }
    }
}
