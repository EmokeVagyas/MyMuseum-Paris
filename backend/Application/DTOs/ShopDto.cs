using System.Collections.Generic;

namespace Backend.Application.DTOs
{
    public class ShopDto
    {
        public required string Name { get; set; }

        public required TimeTableDto TimeTable { get; set; }
    }
}