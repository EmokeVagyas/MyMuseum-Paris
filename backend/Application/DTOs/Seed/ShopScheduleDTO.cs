using System;

namespace Backend.Application.DTOs.Seed
{
    public class ShopScheduleDto
    {
        public int DayOfWeek { get; set; }
        public string? OpeningTime { get; set; }
        public string? ClosingTime { get; set; }

        public bool IsFree { get; set; }
        public bool IsClosed { get; set; }
        public string? Date { get; set; }
        public string? Description { get; set; }
    }
}
