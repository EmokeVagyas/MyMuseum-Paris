namespace Backend.Domain.Entities
{
    public class TimeTable
    {
        public int TimeTableId { get; set; }
        public int Year { get; set; }

        public List<OpeningPeriod> OpeningPeriods { get; set; } = new List<OpeningPeriod>();
        public List<ExceptionalDay> ExceptionalDays { get; set; } = new List<ExceptionalDay>();
        public List<SpecialRule> SpecialRules { get; set; } = new List<SpecialRule>();
    }
}
