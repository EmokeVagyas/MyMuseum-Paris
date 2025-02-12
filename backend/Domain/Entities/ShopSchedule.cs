using Newtonsoft.Json;

namespace Backend.Domain.Entities
{
    public class ShopSchedule
    {
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; } = null!;
        
        public int ShopId { get; set; }
        public Shop Shop { get; set; } = null!;
    }
}
