using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Backend.Domain.Entities
{
    public class ExceptionalDay
    {
        [Key]
        public int ExceptionalDayId { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public required DateOnly Date { get; set; }
        public bool? IsClosed { get; set; }
        public bool? IsFree { get; set; }
        public required string Description { get; set; }

        // Relationships
        public int ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public Schedule Schedule { get; set; } = null!;

        public required List<OpeningHour> OpeningHours { get; set; }
    }
}