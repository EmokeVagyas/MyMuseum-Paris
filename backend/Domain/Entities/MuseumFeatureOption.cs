using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    [Table("museum_feature_options")]
    public class MuseumFeatureOption
    {
        [Key]
        public int  MuseumFeatureOptionId { get; set; }
        public string? OptionName { get; set; }

        // Relations
        public int MuseumFeatureId { get; set; }
        [ForeignKey("MuseumFeatureId")]
        public MuseumFeature MuseumFeature { get; set; } = null!;
    }
}
