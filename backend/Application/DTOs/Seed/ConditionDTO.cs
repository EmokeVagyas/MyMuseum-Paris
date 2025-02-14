using Backend.Domain.Entities;
using Newtonsoft.Json;

namespace Backend.Application.DTOs.Seed
{
    public class ConditionDto
    {
        public int ConditionId { get; set; }
        public int DayOfWeek { get; set; }
        public int WeekOfMonth { get; set; }
        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly StartTime { get; set; }
        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly EndTime { get; set; }
        public List<int> ExcludedMonths { get; set; } = [];
        public bool IsFree { get; set; }
    }
}

