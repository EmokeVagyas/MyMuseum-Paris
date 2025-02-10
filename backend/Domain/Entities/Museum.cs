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
        public required MuseumEnvironment Environment { get; set; }
        public required Accessibility Accessibility { get; set; }
        public required Languages Languages { get; set; }
        public bool GuidedTours { get; set; }
        public required bool AudioGuide { get; set; } 

        public required int ShopId { get; set; }
        public required Shop Shop { get; set; }
        
        public int? CityId { get; set; }
        public City City { get; set; } = null!;

        public required List<MuseumSchedule> MuseumSchedules { get; set; } = [];
        public required List<MuseumFeatureAssociation> MuseumFeatureAssociations { get; set; } = [];
    }
 }

