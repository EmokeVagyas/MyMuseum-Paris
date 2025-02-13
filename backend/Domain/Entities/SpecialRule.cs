using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    [Table("special_rules")]
    public class SpecialRule
    {
        [Key]
        public int SpecialRuleId { get; set; }
        public required string RuleType { get; set; }
        public required string Description { get; set; }

        // Relations
        public int ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public Schedule Schedule { get; set; } = null!;

        public int ConditionId { get; set; }
        [ForeignKey("ConditionId")]
        public required Condition Condition { get; set; }
    }
}