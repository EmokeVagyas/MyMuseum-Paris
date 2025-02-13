using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    [Table("schedules")]
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public int Year { get; set; }

        // Relations
        public required List<OpeningPeriod> OpeningPeriods { get; set; }
        public required List<ExceptionalDay> ExceptionalDays { get; set; }
        public required List<SpecialRule> SpecialRules { get; set; }
    }
}