namespace Backend.Domain.Entities
{
    public class SpecialRule
    {
        public int SpecialRuleId { get; set; }
        public required string RuleType { get; set; }
        public required string Description { get; set; }

        // Relations
        // Relationships
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; } = null!;

        public int ConditionId { get; set; }
        public required Condition Condition { get; set; }
    }
}