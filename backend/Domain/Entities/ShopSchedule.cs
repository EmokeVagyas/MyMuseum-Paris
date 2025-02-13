using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    [Table("shop_schedules")]
    public class ShopSchedule
    {
        [Key]
        public int ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public Schedule Schedule { get; set; } = null!;

        [Key]
        public int ShopId { get; set; }
        [ForeignKey("ShopId")]
        public Shop Shop { get; set; } = null!;
    }
}
