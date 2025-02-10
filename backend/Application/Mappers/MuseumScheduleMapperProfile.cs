using AutoMapper;
using Backend.Domain.Entities;
using Backend.Application.DTOs;

namespace Backend.Application.Mappers
{
    public class MuseumScheduleMapperProfile : Profile
    {
        public MuseumScheduleMapperProfile()
        {
            CreateMap<MuseumSchedule, MuseumScheduleDto>()
                .ForMember(dest => dest.TimeTable, opt => opt.MapFrom(src => new TimeTableDto
                {
                    Year = src.Schedule.Year,
                    OpeningPeriods = src.Schedule.OpeningPeriods.Select(op => new OpeningPeriodDto
                    {
                        StartDate = op.StartDate,
                        EndDate = op.EndDate,
                        Description = op.Description,
                        OpeningHours = op.OpeningHours.Select(oh => new OpeningHourDto
                        {
                            DayOfWeek = oh.DayOfWeek,
                            OpeningTime = oh.OpeningTime,
                            ClosingTime = oh.ClosingTime,
                            IsFree = oh.IsFree,
                            IsClosed = oh.IsClosed
                        }).ToList(),
                        LastEntryOffset = op.LastEntryOffset,
                        RoomClearingOffset = op.RoomClearingOffset
                    }).ToList(),
                    ExceptionalDays = src.Schedule.ExceptionalDays.Select(ed => new ExceptionalDayDto
                    {
                        Date = ed.Date,
                        IsClosed = ed.IsClosed,
                        IsFree = ed.IsFree,
                        Description = ed.Description,
                        OpeningHours = ed.OpeningHours.Select(oh => new OpeningHourDto
                        {
                            DayOfWeek = oh.DayOfWeek,
                            OpeningTime = oh.OpeningTime,
                            ClosingTime = oh.ClosingTime,
                            IsFree = oh.IsFree,
                            IsClosed = oh.IsClosed
                        }).ToList()
                    }).ToList()
                }))
                .ForMember(dest => dest.Shop, opt => opt.MapFrom(src => src.Museum.Shop));

            CreateMap<MuseumScheduleDto, MuseumSchedule>()
                .ForMember(dest => dest.Schedule.Year, opt => opt.MapFrom(src => src.TimeTable.Year))
                .ForMember(dest => dest.Schedule.OpeningPeriods, opt => opt.MapFrom(src => src.TimeTable.OpeningPeriods.Select(op => new OpeningPeriod
                {
                    StartDate = op.StartDate,
                    EndDate = op.EndDate,
                    Description = op.Description,
                    OpeningHours = op.OpeningHours.Select(oh => new OpeningHour
                    {
                        DayOfWeek = oh.DayOfWeek,
                        OpeningTime = oh.OpeningTime,
                        ClosingTime = oh.ClosingTime,
                        IsFree = oh.IsFree,
                        IsClosed = oh.IsClosed
                    }).ToList(),
                    LastEntryOffset = op.LastEntryOffset,
                    RoomClearingOffset = op.RoomClearingOffset
                }).ToList()))
                .ForMember(dest => dest.Schedule.ExceptionalDays, opt => opt.MapFrom(src => src.TimeTable.ExceptionalDays.Select(ed => new ExceptionalDay
                {
                    Date = ed.Date,
                    IsClosed = ed.IsClosed,
                    IsFree = ed.IsFree,
                    Description = ed.Description,
                    OpeningHours = ed.OpeningHours.Select(oh => new OpeningHour
                    {
                        DayOfWeek = oh.DayOfWeek,
                        OpeningTime = oh.OpeningTime,
                        ClosingTime = oh.ClosingTime,
                        IsFree = oh.IsFree,
                        IsClosed = oh.IsClosed
                    }).ToList()
                }).ToList()));
        }
    }
}