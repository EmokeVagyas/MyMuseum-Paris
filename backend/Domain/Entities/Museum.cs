using System.Globalization;

namespace Backend.Domain.Entities
{
    public class Museum
    {
        public int MuseumID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool Palace { get; set; }
        public string IndoorOrOutdoor { get; set; }
        public string Accessibility { get; set; }
        public bool GuidedTours { get; set; }
        // Nem lehet postgresben listat tarolni asszem
        public List<string> Languages { get; set; }
        public List<MuseumSchedule> MuseumSchedule { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }
        public MuseumFeatureAssociation MuseumFeatureAssociations { get; set; }
    }
 }

