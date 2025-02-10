using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    public class MuseumFeatureOption
    {
        public int  MuseumFeatureOptionId { get; set; }
        public string? OptionName { get; set; }

        public int MuseumFeatureId { get; set; }
        [ForeignKey("MuseumFeatureId")]
        public MuseumFeature MuseumFeature { get; set; } = null!;
    }
}
