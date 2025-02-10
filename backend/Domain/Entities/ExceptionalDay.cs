using System.Collections.Generic;

namespace Backend.Domain.Entities
{
    public class ExceptionalDay
    {
        public int ExceptionalDayId { get; set; }
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