using Backend.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    [Table("museum_accessibilities")]
    public class MuseumAccessibility
    {
        [Key]
        public int MuseumId { get; set; }
        [ForeignKey("MuseumId")]
        public Museum Museum { get; set; } = null!;

        [Key]
        public Accessibility Accessibility { get; set; }
    }
}