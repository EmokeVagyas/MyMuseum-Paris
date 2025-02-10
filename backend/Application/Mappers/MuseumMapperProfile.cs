using AutoMapper;
using Backend.Domain.Entities;
using Backend.Application.DTOs;

namespace Backend.Application.Mappers
{
    public class MuseumMapperProfile : Profile
    {
        public MuseumMapperProfile()
        {
            CreateMap<Museum, MuseumDTO>().ReverseMap();
        }
    }
}
