namespace Backend.Application.DTOs
{
    public class TimeTableDto
    {
        public int Year { get; set; }
        public List<OpeningPeriodDto> OpeningPeriods { get; set; } = [];
        public List<ExceptionalDayDto> ExceptionalDays { get; set; } = [];
        public List<SpecialRuleDto> SpecialRules { get; set; } = [];
    }
}
