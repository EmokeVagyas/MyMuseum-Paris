namespace Backend.Domain.Entities
{
    public class GroupQuestionnaireResponse
    {
        public int GroupID { get; set; }
        public int UserID { get; set; }
        public int FeatureID { get; set; }
        public int OptionID { get; set; }

        public User User { get; set; }
        public MuseumFeature MuseumFeature { get; set; }
        public MuseumFeatureOption MuseumFeatureOption { get; set; }
    }
}
