using Newtonsoft.Json;
using Backend.Domain.Entities;

namespace Backend.Application.DTOs.Seed
{
    public class OpeningPeriodDto
    {
        [JsonConverter(typeof(MonthDayJsonConverter))]
        public DateOnly StartDate { get; set; }
        [JsonConverter(typeof(MonthDayJsonConverter))]
        public DateOnly EndDate { get; set; }
        public string Description { get; set; }
        public List<OpeningHourDto> OpeningHours { get; set; }
        public TimeSpan? LastEntryOffset { get; set; }
        public TimeSpan? RoomClearingOffset { get; set; }
    }
}