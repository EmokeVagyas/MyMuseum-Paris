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
        public required Museum Museum { get; set; }

        public int MuseumFeatureOptionId { get; set; }
        [ForeignKey("MuseumFeatureOptionId")]
        public required MuseumFeatureOption MuseumFeatureOption { get; set; }
    }
}
