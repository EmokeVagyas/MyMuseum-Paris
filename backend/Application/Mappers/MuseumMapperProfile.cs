using AutoMapper;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using System.Linq;
using Backend.Application.DTOs.Seed;
using Backend.Application.DTOs.Museum;
using Backend.API.DTOs.Responses;

namespace Backend.Application.Mappers
{
    public class MuseumMapperProfile : Profile
    {
        public MuseumMapperProfile()
        {
            // Mapping for Condition to ConditionDTO
            CreateMap<Condition, ConditionDto>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToString("HH:mm")))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToString("HH:mm")));

            // Mapping for SpecialRule to SpecialRuleDto
            CreateMap<SpecialRule, SpecialRuleDto>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.RuleType, opt => opt.MapFrom(src => src.RuleType))
                .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Condition));

            CreateMap<MuseumDto, Museum>()
                .ForMember(dest => dest.MuseumId, opt => opt.MapFrom(src => src.MuseumId))
                .ForMember(dest => dest.Accessibilities, opt => opt.MapFrom(src => src.Accessibilities.Select(a => new MuseumAccessibility
                {
                    MuseumId = src.MuseumId,
                    Accessibility = a
                })))
                .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.Languages.Select(l => new MuseumLanguage
                {
                    MuseumId = src.MuseumId,
                    Language = l
                })));

            // INNENTOL LEFELE IRD, FENT SEED DTO


            CreateMap<Museum, GetMuseumDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MuseumId));

            CreateMap<Schedule, TimeTableDto>()
            .ForMember(dest => dest.OpeningPeriods, opt => opt.MapFrom(src => src.OpeningPeriods.ToString()))
            .ForMember(dest => dest.ExceptionalDays, opt => opt.MapFrom(src => src. ExceptionalDays.ToString()))
            .ForMember(dest => dest.SpecialRules, opt => opt.MapFrom(src => src.SpecialRules.ToString()));

            CreateMap<IEnumerable<GetMuseumDto>, GetMuseumsResponse>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));


            //    .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.Languages))
            //    .ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules))
            //    .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId));
        }
    }
}
