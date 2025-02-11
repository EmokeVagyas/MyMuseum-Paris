using Newtonsoft.Json;

namespace Backend.Domain.Entities
{
    public class ShopSchedule
    {
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; } = null!;
        public int ShopId { get; set; }
        public Shop Shop { get; set; } = null!;

        public int DayOfWeek { get; set; }

        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly? OpeningTime { get; set; }

        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly? ClosingTime { get; set; }

        public bool IsFree { get; set; }
        public bool IsClosed { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? Date { get; set; } 
        public string? Description { get; set; }
    }
}
