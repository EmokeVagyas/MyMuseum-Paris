using System.Collections.Generic;

namespace Backend.Application.DTOs.Seed
{
    public class ShopDto
    {
        public required string Name { get; set; }

        public required TimeTableDto TimeTable { get; set; }
    }
}