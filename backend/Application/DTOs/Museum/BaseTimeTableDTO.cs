using Backend.Application.DTOs.Seed;

namespace Backend.Application.DTOs.Museum
{
    public class BaseTimetableDto
    {
        public int Year { get; set; }
        public List<OpeningPeriodDto> OpeningPeriods { get; set; } = [];
        public List<ExceptionalDayDto> ExceptionalDays { get; set; } = [];
        public List<SpecialRuleDto> SpecialRules { get; set; } = [];
    }
}
