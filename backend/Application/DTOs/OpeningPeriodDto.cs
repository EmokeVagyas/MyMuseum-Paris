using Newtonsoft.Json;
using Backend.Domain.Entities;

namespace Backend.Application.DTOs
{
    public class OpeningPeriodDto
    {
        [JsonConverter(typeof(MonthDayJsonConverter))]
        public required DateOnly StartDate { get; set; }
        [JsonConverter(typeof(MonthDayJsonConverter))]
        public required DateOnly EndDate { get; set; }
        public required string Description { get; set; }
        public required List<OpeningHourDto> OpeningHours { get; set; }
        public required string LastEntryOffset { get; set; }
        public required string RoomClearingOffset { get; set; }
    }
}