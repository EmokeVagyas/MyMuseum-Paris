namespace Backend.Domain.Entities
{
    /// <summary>
    /// Join Table
    /// </summary>
    public class MuseumFeatureAssociation
    {
        public int MuseumID { get; set; }
        public int MuseumFeatureOptionID { get; set; }

        public required Museum Museum { get; set; }
        public required MuseumFeatureOption MuseumFeatureOption { get; set; }
    }
}
