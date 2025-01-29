using System.Globalization;

namespace Backend.Domain.Entities
{
    public class Museum
    {
        public int MuseumID { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string Description { get; set; }
        public required bool Palace { get; set; }
        public required string IndoorOrOutdoor { get; set; }
        public required string Accessibility { get; set; }
        public bool GuidedTours { get; set; }
        // Nem lehet postgresben listat tarolni asszem
        public List<string> Languages { get; set; } = [];
        public List<MuseumSchedule> MuseumSchedule { get; set; } = [];

        public int? CityId { get; set; }
        public City City { get; set; } = null!;
        public MuseumFeatureAssociation MuseumFeatureAssociations { get; set; } = null!;
    }
 }

