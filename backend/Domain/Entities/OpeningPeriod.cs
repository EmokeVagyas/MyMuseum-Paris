using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Backend.Domain.Entities
{
    public class OpeningPeriod
    {
        [Key]
        public int OpeningPeriodId { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public required DateOnly StartDate { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public required DateOnly EndDate { get; set; }
        public required string Description { get; set; }

        public required TimeSpan? LastEntryOffset { get; set; }
        public required TimeSpan? RoomClearingOffset { get; set; }

        // Relationships
        public int ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public Schedule Schedule { get; set; } = null!;

        public required List<OpeningHour> OpeningHours { get; set; }
    }
}