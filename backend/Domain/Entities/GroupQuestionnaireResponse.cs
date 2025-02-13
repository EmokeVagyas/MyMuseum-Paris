using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    [Table("group_questionnaire_responses")]
    public class GroupQuestionnaireResponse
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public int FeatureId { get; set; }
        public int OptionId { get; set; }
        public required User User { get; set; }
        public required MuseumFeature MuseumFeature { get; set; }
        public required MuseumFeatureOption MuseumFeatureOption { get; set; }
    }
}
