using AutoMapper;
using Backend.Domain.Entities;
using Backend.Application.DTOs;

namespace Backend.Application.Mappers
{
    public class MuseumScheduleMapperProfile : Profile
    {
        public MuseumScheduleMapperProfile()
        {
            //CreateMap<MuseumSchedule, MuseumScheduleDto>()
            //    .ForMember(dest => dest.TimeTable, opt => opt.MapFrom(src => new TimeTableDto
            //    {
            //        Year = src.Schedule.Year,
            //        OpeningPeriods = src.Schedule.OpeningPeriods.Select(op => new OpeningPeriodDto
            //        {
            //            StartDate = op.StartDate,
            //            EndDate = op.EndDate,
            //            Description = op.Description,
            //            OpeningHours = op.OpeningHours.Select(oh => new OpeningHourDto
            //            {
            //                DayOfWeek = oh.DayOfWeek,
            //                OpeningTime = oh.OpeningTime,
            //                ClosingTime = oh.ClosingTime,
            //                IsFree = oh.IsFree,
            //                IsClosed = oh.IsClosed
            //            }).ToList(),
            //            LastEntryOffset = op.LastEntryOffset,
            //            RoomClearingOffset = op.RoomClearingOffset
            //        }).ToList(),
            //        ExceptionalDays = src.Schedule.ExceptionalDays.Select(ed => new ExceptionalDayDto
            //        {
            //            Date = ed.Date,
            //            IsClosed = ed.IsClosed,
            //            IsFree = ed.IsFree,
            //            Description = ed.Description,
            //            OpeningHours = ed.OpeningHours.Select(oh => new OpeningHourDto
            //            {
            //                DayOfWeek = oh.DayOfWeek,
            //                OpeningTime = oh.OpeningTime,
            //                ClosingTime = oh.ClosingTime,
            //                IsFree = oh.IsFree,
            //                IsClosed = oh.IsClosed
            //            }).ToList()
            //        }).ToList()
            //    }))
            //    .ForMember(dest => dest.Shop, opt => opt.MapFrom(src => src.Museum.Shop));

            CreateMap<MuseumScheduleDto, MuseumSchedule>()
                .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src => new Schedule
                {
                    Year = src.TimeTable.Year,
                    OpeningPeriods = src.TimeTable.OpeningPeriods.Select(op => new OpeningPeriod
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
                    }).ToList(),
                    ExceptionalDays = src.TimeTable.ExceptionalDays.Select(ed => new ExceptionalDay
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
                    }).ToList(),
                    SpecialRules = src.TimeTable.SpecialRules.Select(sr => new SpecialRule
                    {
                        Description = sr.Description,
                        RuleType = sr.RuleType,
                        Condition = new Condition
                        {
                            ConditionId = sr.Condition.ConditionId,
                            DayOfWeek = sr.Condition.DayOfWeek,
                            WeekOfMonth = sr.Condition.WeekOfMonth,
                            StartTime = sr.Condition.StartTime,
                            EndTime = sr.Condition.EndTime,
                            ExcludedMonths = sr.Condition.ExcludedMonths.Select(em => new ConditionExcludedMonth
                            {
                                ConditionId = sr.Condition.ConditionId,
                                ExcludedMonth = em
                            }).ToList(),
                        }
                    }).ToList()
                }));

            CreateMap<MuseumScheduleDto, List<Shop>>()
                .ConvertUsing(dto => dto.Shop == null ? new List<Shop>() : dto.Shop
                    .Select(shop => new Shop
                    {
                        Name = shop.Name,
                        MuseumId = dto.MuseumId,
                        ShopSchedules = new() {new ShopSchedule
                        {
                            Schedule = new Schedule
                            {
                                Year = shop.TimeTable.Year,
                                OpeningPeriods = shop.TimeTable.OpeningPeriods.Select(op => new OpeningPeriod
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
                                }).ToList(),
                                ExceptionalDays = shop.TimeTable.ExceptionalDays.Select(ed => new ExceptionalDay
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
                                }).ToList(),
                                SpecialRules = shop.TimeTable.SpecialRules.Select(sr => new SpecialRule
                                {
                                    Description = sr.Description,
                                    RuleType = sr.RuleType,
                                    Condition = new Condition
                                    {
                                        ConditionId = sr.Condition.ConditionId,
                                        DayOfWeek = sr.Condition.DayOfWeek,
                                        WeekOfMonth = sr.Condition.WeekOfMonth,
                                        StartTime = sr.Condition.StartTime,
                                        EndTime = sr.Condition.EndTime,
                                        ExcludedMonths = sr.Condition.ExcludedMonths.Select(em => new ConditionExcludedMonth
                                        {
                                            ConditionId = sr.Condition.ConditionId,
                                            ExcludedMonth = em
                                        }).ToList(),
                                    }
                                }).ToList()
                            }
                        } }
                    }).ToList());
        }
    }
}