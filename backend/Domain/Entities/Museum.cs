using Backend.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Backend.Domain.Entities
{
    public class Museum
    {
        [Key]
        public int MuseumId { get; set; }

        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string Description { get; set; }
        public MuseumEnvironment Environment { get; set; }
        public required List<MuseumAccessibility> Accessibilities { get; set; }
        public required List<MuseumLanguage> Languages { get; set; }
        public bool GuidedTours { get; set; }
        public bool AudioGuide { get; set; }

        public int CityId { get; set; }
        public City City { get; set; } = null!;

        public List<MuseumSchedule> Schedules { get; set; } = [];
        public List<MuseumFeatureAssociation> FeatureAssociations { get; set; } = [];
        public List<Shop> Shops { get; set; } = [];
    }
}

