using Newtonsoft.Json;

namespace Backend.Domain.Entities
{
    public class OpeningHour
    {
        public int OpeningHourId { get; set; }
        public int DayOfWeek { get; set; }

        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly? OpeningTime { get; set; }

        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly? ClosingTime { get; set; }

        public bool IsFree { get; set; }
        public bool IsClosed { get; set; }
        public int? ShopId { get; set; }

        // Relationships
        public int? ExceptionalDayId { get; set; }
        public ExceptionalDay ExceptionalDay { get; set; } = null!;

    }
}