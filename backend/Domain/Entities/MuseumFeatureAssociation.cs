using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    /// <summary>
    /// Join Table
    /// </summary>
    public class MuseumFeatureAssociation
    {
        public int MuseumId { get; set; }
        [ForeignKey("MuseumId")]
        public Museum Museum { get; set; }

        public int MuseumFeatureOptionId { get; set; }
        [ForeignKey("MuseumFeatureOptionId")]
        public MuseumFeatureOption? MuseumFeatureOption { get; set; }
    }
}
