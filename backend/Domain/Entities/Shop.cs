using System.Collections.Generic;

namespace Backend.Domain.Entities
{
    public class Shop
    {
        public int ShopId { get; set; }
        public required string Name { get; set; }

        public required List<ShopSchedule> ShopSchedules { get; set; }
    }
}