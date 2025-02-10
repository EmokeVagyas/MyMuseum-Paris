using System.Collections.Generic;

namespace Backend.Domain.Entities
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int Year { get; set; }

        public required List<OpeningPeriod> OpeningPeriods { get; set; }
        public required List<ExceptionalDay> ExceptionalDays { get; set; }
    }
}