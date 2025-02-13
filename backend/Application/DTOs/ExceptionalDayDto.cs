using Backend.Domain.Entities;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Backend.Application.DTOs
{
    public class ExceptionalDayDto
    {
        [JsonConverter(typeof(MonthDayJsonConverter))]
        public required DateOnly Date { get; set; }
        public bool? IsClosed { get; set; }
        public bool? IsFree { get; set; }
        public required string Description { get; set; }
        public List<OpeningHourDto> OpeningHours { get; set; } = [];
    }
}