using System.Collections.Generic;
using Newtonsoft.Json;

namespace Backend.Domain.Entities
{
    public class ExceptionalDay
    {
        public int ExceptionalDayId { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public required DateOnly Date { get; set; }
        public bool? IsClosed { get; set; }
        public bool? IsFree { get; set; }
        public required string Description { get; set; }

        // Relationships
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; } = null!;

        public required List<OpeningHour> OpeningHours { get; set; }
    }
}