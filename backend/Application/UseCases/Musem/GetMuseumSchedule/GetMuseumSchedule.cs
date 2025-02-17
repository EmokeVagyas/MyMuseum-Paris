
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Backend.Application.DTOs.Museum;
using System.Diagnostics.Eventing.Reader;
using Backend.Domain.Entities;

namespace Backend.Application.UseCases.Musem.GetMuseumSchedule
{
    public class GetMuseumSchedule : IGetMuseumSchedule
    {
        private readonly IMuseumRepository _museumRepository;
        private readonly AppDbContext _context;

        public GetMuseumSchedule(IMuseumRepository museumRepository, AppDbContext context)
        {
            _museumRepository = museumRepository;
            _context = context;
        }

        public async Task<Dictionary<DateOnly, MuseumDailySchedule>> ExecuteAsync(int museumId, DateOnly fromDate, DateOnly toDate)
        {
            var result = new Dictionary<DateOnly, MuseumDailySchedule>();
            var year = fromDate.Year;

            var museum = await _context.Museums
                .Where(m => m.MuseumId == museumId)
                .Include(m => m.Schedules)
                    .ThenInclude(ms => ms.Schedule)
                        .ThenInclude(s => s.OpeningPeriods!)
                        .ThenInclude(op => op.OpeningHours)
                .Include(m => m.Schedules)
                    .ThenInclude(ms => ms.Schedule)
                        .ThenInclude(s => s.ExceptionalDays!)
                        .ThenInclude(ed => ed.OpeningHours)
                .FirstOrDefaultAsync();

            if (museum == null)
            {
                return result;
            }

            // Loop for each day from start to end date
            for (var day = fromDate; day <= toDate; day = day.AddDays(1))
            {
                var schedule = GetScheduleForDay(museum, day);
                result.Add(day, schedule);
            }

            return result;
            //var schedules = museum.Schedules
            //    .Select(m => m.Schedule)
            //    .Distinct()
            //    .ToList();

            //var scheduleDictionary = new Dictionary<DateOnly, List<SchedulePeriodDto>>();
            //var fromDateTime = fromDate.ToDateTime(TimeOnly.MinValue);
            //var toDateTime = toDate.ToDateTime(TimeOnly.MaxValue);

            //foreach (var schedule in schedules)
            //{
            //    foreach (var openingPeriod in schedule.OpeningPeriods)
            //    {
            //        var periodStart = openingPeriod.StartDate.ToDateTime(TimeOnly.MinValue);
            //        var periodEnd = openingPeriod.EndDate.ToDateTime(TimeOnly.MaxValue);

            //        var actualStart = (periodStart < fromDateTime) ? fromDateTime : periodStart;
            //        var actualEnd = (periodEnd > toDateTime) ? toDateTime : periodEnd;

            //        if (actualStart > actualEnd)
            //            continue;

            //        for (var day = actualStart.Date; day <= actualEnd.Date; day = day.AddDays(1))
            //        {
            //            var dayKey = DateOnly.FromDateTime(day);
            //            var dayOfWeek = (int)day.DayOfWeek;

            //            if (!scheduleDictionary.ContainsKey(dayKey))
            //            {
            //                scheduleDictionary[dayKey] = new List<SchedulePeriodDto>();
            //            }

            //            var openingHoursForDay = openingPeriod.OpeningHours
            //                .Where(oh => oh.DayOfWeek == dayOfWeek)
            //                .ToList();

            //            if (!openingHoursForDay.Any())
            //            {
            //                foreach (var oh in openingHoursForDay)
            //                {
            //                    if (oh.IsClosed)
            //                    {
            //                        scheduleDictionary[dayKey].Clear();
            //                        scheduleDictionary[dayKey].Add(new SchedulePeriodDto
            //                        {
            //                            Start = day.ToDateTime(TimeOnly.MinValue),
            //                            End = day.ToDateTime(TimeOnly.MaxValue),
            //                            IsClosed = true,
            //                            IsFree = false,
            //                        });
            //                        break;
            //                    }

            //                    var ohStart = day.ToDateTime(oh.OpeningTime ?? TimeOnly.MinValue);
            //                    var ohEnd = day.ToDateTime(oh.ClosingTime ?? TimeOnly.MaxValue);

            //                    scheduleDictionary[dayKey].Add(new SchedulePeriodDto
            //                    {
            //                        Start = ohStart,
            //                        End = ohEnd,
            //                        IsClosed = false,
            //                        IsFree = oh.IsFree
            //                    });
            //                }
            //            }
            //            else
            //            {
            //                scheduleDictionary[dayKey].Add(new SchedulePeriodDto
            //                {
            //                    Start = day.ToDateTime(TimeOnly.MinValue),
            //                    End = day.ToDateTime(TimeOnly.MaxValue),
            //                    IsClosed = true,
            //                    IsFree = false
            //                });
            //            }
            //        }
            //    }
            //}

            //foreach (var schedule in schedules)
            //{
            //    var relevantExDays = schedule.ExceptionalDays
            //        .Where(ed => ed.Date >= fromDate && ed.Date <= toDate)
            //        .ToList();

            //    foreach (var exDay in relevantExDays)
            //    {
            //        var dayKey = exDay.Date;

            //        if (!scheduleDictionary.ContainsKey(dayKey))
            //        {
            //            scheduleDictionary[dayKey] = new List<SchedulePeriodDto>();
            //        }

            //        if (exDay.IsClosed == true)
            //        {
            //            scheduleDictionary[dayKey].Clear();
            //            scheduleDictionary[dayKey].Add(new SchedulePeriodDto
            //            {
            //                Start = exDay.Date.ToDateTime(TimeOnly.MinValue),
            //                End = exDay.Date.ToDateTime(TimeOnly.MaxValue),
            //                IsClosed = true,
            //                IsFree = false
            //            });
            //            continue;
            //        }

            //        if (exDay.OpeningHours != null && exDay.OpeningHours.Any())
            //        {
            //            scheduleDictionary[dayKey].Clear();

            //            foreach (var oh in exDay.OpeningHours)
            //            {
            //                var ohStart = exDay.Date.ToDateTime(oh.OpeningTime ?? TimeOnly.MinValue);
            //                var ohEnd = exDay.Date.ToDateTime(oh.ClosingTime ?? TimeOnly.MaxValue);

            //                scheduleDictionary[dayKey].Add(new SchedulePeriodDto
            //                {
            //                    Start = ohStart,
            //                    End = ohEnd,
            //                    IsClosed = false,
            //                    IsFree = oh.IsFree
            //                });
            //            }
            //        }
            //    }
            //}

            //return scheduleDictionary.ToDictionary(
            //    kvp => kvp.Key,
            //    kvp => kvp.Value.AsEnumerable()
            //);
        }

        public MuseumDailySchedule GetScheduleForDay(Museum museum, DateOnly date)
        {
            var res = new MuseumDailySchedule();

            var museumSchedule = _context.MuseumSchedules
                .Include(ms => ms.Schedule)
                    .ThenInclude(s => s.OpeningPeriods)
                .Include(ms => ms.Schedule)
                    .ThenInclude(s => s.ExceptionalDays)
                .Include(ms => ms.Schedule)
                    .ThenInclude(s => s.SpecialRules)
                .Where(ms => ms.MuseumId == museum.MuseumId)
                .Select(ms => ms.Schedule)
                .Where(s => s.Year == date.Year)
                .FirstOrDefault();

            if (museumSchedule == null)
            {
                return res;
            }

            // 1. Lepes: Azt az opening periodot valasztani amelyik beleesik a date-ba
            var openingPeriod = museumSchedule.OpeningPeriods
                .Where(op => op.StartDate <= date && op.EndDate >= date)
                .FirstOrDefault();

            if (openingPeriod == null)
            {
                return res;
            }

            // 2. Lepes: Az opening periodnak meg kell nezni az opening hours-jait es kivalasztani azt a DayOfWeek-et amelyikre a date esik
            var openingHour = openingPeriod.OpeningHours
                .Where(oh => oh.DayOfWeek == (int)date.DayOfWeek)  
                .FirstOrDefault();

            if (openingHour == null)
            {
                res.IsClosed = true;
                return res;
            }

            // 3. lepes: Az opening hours alapjan szamoljuk ki a LastEntry es a RoomClearing idopontokat
            res.IsClosed = false;
            res.RoomClearing = openingHour.ClosingTime?.Add(openingPeriod.RoomClearingOffset ?? TimeSpan.Zero);
            res.LastEntry = openingHour.ClosingTime?.Add(openingPeriod.LastEntryOffset ?? TimeSpan.Zero);
                
            res.Schedules = new List<OpeningHour>() { openingHour }.Select(oh => new SchedulePeriodDto
            {
                Start = date.ToDateTime(oh.OpeningTime ?? TimeOnly.MinValue),
                End = date.ToDateTime(oh.ClosingTime ?? TimeOnly.MaxValue),
                IsFree = oh.IsFree,
            });

            return res;
        }

    }
}

