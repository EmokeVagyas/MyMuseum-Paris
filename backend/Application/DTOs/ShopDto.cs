using System.Collections.Generic;

namespace Backend.Application.DTOs
{
    public class ShopDto
    {
        public required string Name { get; set; }
        public required List<OpeningHourDto> OpeningHours { get; set; }
        public required List<ExceptionalDayDto> ExceptionalDays { get; set; }
    }
}