
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    [Table("shops")]
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }
        public required string Name { get; set; }

        // Relations
        public int MuseumId { get; set; }
        [ForeignKey("MuseumId")]
        public Museum Museum { get; set; } = null!;
        public List<ShopSchedule> ShopSchedules { get; set; } = [];
    }
}