using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    public class MuseumFeatureOption
    {
        public int  MuseumFeatureOptionID { get; set; }
        public int MuseumFeatureID { get; set; }
        public string? OptionName { get; set; }


        [ForeignKey("MuseumFeatureID")]
        public MuseumFeature MuseumFeature { get; set; } = null!;
    }
}
