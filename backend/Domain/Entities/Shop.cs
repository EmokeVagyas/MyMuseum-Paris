using System.Collections.Generic;

namespace Backend.Domain.Entities
{
    public class Shop
    {
        public int ShopId { get; set; }
        public required string Name { get; set; }

        // Relations
        public int MuseumId { get; set; }
        public Museum Museum { get; set; } = null!;
        public required List<ShopSchedule> ShopSchedules { get; set; }
    }
}