using Newtonsoft.Json;
using System.Collections.Generic;

namespace Backend.Domain.Entities
{
    public class Condition
    {
        public int ConditionId { get; set; }
        public required int DayOfWeek { get; set; }
        public required int WeekOfMonth { get; set; }

        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly StartTime { get; set; }

        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly EndTime { get; set; }

        public required List<int> ExcludedMonths { get; set; }
        public bool IsFree { get; set; }
    }
}