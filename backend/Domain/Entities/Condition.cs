using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Backend.Domain.Entities
{
    public class Condition
    {
        [Key]
        public int ConditionId { get; set; }
        public int DayOfWeek { get; set; }
        public int WeekOfMonth { get; set; }

        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly StartTime { get; set; }

        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly EndTime { get; set; }
        public bool IsFree { get; set; }

        // Relations
        public List<ConditionExcludedMonth> ExcludedMonths { get; set; } = [];
        public SpecialRule? SpecialRule { get; set; }
    }
}