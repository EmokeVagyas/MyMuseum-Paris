using System.Collections.Generic;

namespace Backend.Application.DTOs
{
    public class TimeTableDto
    {
        public int Year { get; set; }
        public required List<OpeningPeriodDto> OpeningPeriods { get; set; }
        public required List<ExceptionalDayDto> ExceptionalDays { get; set; }
    }
}