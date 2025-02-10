using System.Collections.Generic;

namespace Backend.Application.DTOs
{
    public class ExceptionalDayDto
    {
        public required DateOnly Date { get; set; }
        public bool? IsClosed { get; set; }
        public bool? IsFree { get; set; }
        public required string Description { get; set; }
        public required List<OpeningHourDto> OpeningHours { get; set; }
    }
}