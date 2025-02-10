using Newtonsoft.Json;
using Backend.Domain.Entities;

namespace Backend.Application.DTOs
{
    public class OpeningHourDto
    {
        public int DayOfWeek { get; set; }

        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly? OpeningTime { get; set; }

        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly? ClosingTime { get; set; }

        public bool IsFree { get; set; }
        public bool IsClosed { get; set; }
    }
}