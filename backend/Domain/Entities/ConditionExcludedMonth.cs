namespace Backend.Domain.Entities
{
    public class ConditionExcludedMonth
    {
        public int ConditionId { get; set; }
        public Condition Condition { get; set; } = null!;

        public int ExcludedMonth { get; set; }
    }
}
