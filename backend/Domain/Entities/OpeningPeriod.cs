using System.Collections.Generic;
using Newtonsoft.Json;

namespace Backend.Domain.Entities
{
    public class OpeningPeriod
    {
        public int OpeningPeriodId { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public required DateOnly StartDate { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public required DateOnly EndDate { get; set; }
        public required string Description { get; set; }
        public required string LastEntryOffset { get; set; }
        public required string RoomClearingOffset { get; set; }

        // Relationships
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; } = null!;

        public required List<OpeningHour> OpeningHours { get; set; }
    }
}