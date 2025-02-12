using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    /// <summary>
    /// Join Table
    /// </summary>
    public class MuseumFeatureAssociation
    {
        [Key]
        public int MuseumId { get; set; }
        [ForeignKey("MuseumId")]
        public Museum Museum { get; set; }

        [Key]
        public int MuseumFeatureOptionId { get; set; }
        [ForeignKey("MuseumFeatureOptionId")]
        public MuseumFeatureOption MuseumFeatureOption { get; set; }
    }
}
