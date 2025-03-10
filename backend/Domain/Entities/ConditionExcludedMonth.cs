﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    [Table("condition_excluded_months")]
    public class ConditionExcludedMonth
    {
        [Key]
        public int ConditionId { get; set; }
        [ForeignKey("ConditionId")]
        public Condition Condition { get; set; } = null!;

        [Key]
        public int ExcludedMonth { get; set; }
    }
}
