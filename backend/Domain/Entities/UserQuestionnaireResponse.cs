using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    public class UserQuestionnaireResponse
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int FeatureId { get; set; }
        [Key]
        public int OptionId { get; set; }

        [ForeignKey("UserId")]
        public required User User { get; set; }
        [ForeignKey("FeatureId")]
        public required MuseumFeature MuseumFeature { get; set; }
        [ForeignKey("OptionId")]
        public required MuseumFeatureOption MuseumFeatureOption { get; set; }
    }
}
