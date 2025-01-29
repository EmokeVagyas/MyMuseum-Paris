﻿namespace Backend.Domain.Entities
{
    public class UserQuestionnaireResponse
    {
        public int UserID { get; set; }
        public int FeatureID { get; set; }
        public int OptionID { get; set; }
        public required User User { get; set; }
        public required MuseumFeature MuseumFeature { get; set; }
        public required MuseumFeatureOption MuseumFeatureOption { get; set; }
    }
}
