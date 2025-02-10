namespace Backend.Domain.Entities
{
    public class SpecialRule
    {
        public int SpecialRuleId { get; set; }
        public required string RuleType { get; set; }
        public required Condition Condition { get; set; }
        public required string Description { get; set; }
    }
}