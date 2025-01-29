namespace Backend.Domain.Entities
{
    /// <summary>
    /// Join Table
    /// </summary>
    public class MuseumFeatureAssociation
    {
        public int MuseumID { get; set; }
        public int MuseumFeatureOptionID { get; set; }

        public Museum Museum { get; set; }
        public MuseumFeatureOption MuseumFeatureOption { get; set; }
    }
}
