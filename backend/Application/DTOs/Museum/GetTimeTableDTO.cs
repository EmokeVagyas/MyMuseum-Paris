using Backend.Application.DTOs.Seed;
using System.Collections.Generic;

namespace Backend.Application.DTOs.Museum
{
    public class GetTimetableDto
    {
        public int MuseumId { get; set; }
        public int Year { get; set; }
        public List<OpeningPeriodDto> OpeningPeriods { get; set; } = [];
        public List<ExceptionalDayDto> ExceptionalDays { get; set; } = [];
        public List<SpecialRuleDto> SpecialRules { get; set; } = [];
    }
}
