using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    public class MuseumSchedule
    {
        [Key]
        public int MuseumId { get; set; }
        [ForeignKey("MuseumId")]
        public Museum Museum { get; set; } = null!;

        [Key]
        public int ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public Schedule Schedule { get; set; } = null!;
    }
}
