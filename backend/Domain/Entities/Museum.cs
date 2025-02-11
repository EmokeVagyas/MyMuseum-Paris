using Backend.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Backend.Domain.Entities
{
    public class Museum
    {
        [Key]
        public int MuseumId { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public MuseumEnvironment Environment { get; set; }
        public List<MuseumAccessibility> Accessibilities { get; set; }
        public List<MuseumLanguage> Languages { get; set; }
        public bool GuidedTours { get; set; }
        public bool AudioGuide { get; set; }

        public int CityId { get; set; }
        public City City { get; set; } = null!;

        public List<MuseumSchedule> Schedules { get; set; } = [];
        public List<MuseumFeatureAssociation> FeatureAssociations { get; set; } = [];
        public List<Shop> Shops { get; set; }
    }
}

