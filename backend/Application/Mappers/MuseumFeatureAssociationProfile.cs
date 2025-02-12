using AutoMapper;
using Backend.Application.DTOs;
using Backend.Domain.Entities;

namespace Backend.Application.Mappers
{
    public class MuseumFeatureAssociationProfile : Profile
    {
        public MuseumFeatureAssociationProfile()
        {
            CreateMap<MuseumFeatureAssociationDto, List<MuseumFeatureAssociation>>()
                .ConvertUsing(dto => dto.MuseumFeatureOptionIds
                    .Select(optionId => new MuseumFeatureAssociation
                    {
                        MuseumId = dto.MuseumId,
                        MuseumFeatureOptionId = optionId
                    })
                    .ToList());
        }
    }
}
