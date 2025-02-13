using AutoMapper;
using Backend.Domain.Entities;
using Backend.Application.DTOs;
using Backend.Domain.Enums;
using System.Linq;

namespace Backend.Application.Mappers
{
    public class MuseumMapperProfile : Profile
    {
        public MuseumMapperProfile()
        {
            // Mapping for Museum to MuseumDto
            //CreateMap<Museum, MuseumDto>()
            //    .ForMember(dest => dest.Accessibilities, opt => opt.MapFrom(src => src.Accessibilities))
            //    .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.Languages))
            //    .ForMember(dest => dest.MuseumSchedule, opt => opt.MapFrom(src => src.Schedules.FirstOrDefault()))
            //    .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId));

            //// Mapping for MuseumAccessibility to AccessibilityDTO
            //CreateMap<MuseumAccessibility, AccessibilityDto>()
                //.ForMember(dest => dest.AccessibilityType, opt => opt.MapFrom(src => Enum.GetName(typeof(Accessibility), src.Accessibility)));

            // Mapping for MuseumLanguage to LanguageDTO
            //CreateMap<MuseumLanguage, LanguageDto>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Language));

            // Mapping for MuseumSchedule to MuseumScheduleDto
            //CreateMap<MuseumSchedule, MuseumScheduleDto>()
            //    .ForMember(dest => dest.Shop, opt => opt.MapFrom(src => src.TimeTable));

            // Mapping for Condition to ConditionDTO
            CreateMap<Condition, ConditionDto>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToString("HH:mm")))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToString("HH:mm")));

            // Mapping for SpecialRule to SpecialRuleDTO
            CreateMap<SpecialRule, SpecialRuleDto>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.RuleType, opt => opt.MapFrom(src => src.RuleType))
                .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Condition));

            // Mapping for Shop to ShopDto
            //CreateMap<Shop, ShopDto>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(dest => dest.OpeningHours, opt => opt.MapFrom(src => src.ShopSchedules.Select(s => new OpeningHourDto
            //    {
            //        DayOfWeek = s.DayOfWeek,
            //        OpeningTime = s.OpeningTime,
            //        ClosingTime = s.ClosingTime,
            //        IsFree = s.IsFree,
            //        IsClosed = s.IsClosed
            //    }).ToList())) // Mapping ShopSchedules to OpeningHourDto
            //    .ForMember(dest => dest.ExceptionalDays, static opt => opt.MapFrom(static src => src.ShopSchedules.Select(static s => new ExceptionalDayDto
            //    {
            //        Date = s.Date ?? default,
            //        IsClosed = s.IsClosed,
            //        IsFree = s.IsFree,
            //        Description = s.Description ?? "No description available"
            //    }).ToList()));

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
                })))
                ;

            //    .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.Languages))
            //    .ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules))
            //    .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId));
        }
    }
}
