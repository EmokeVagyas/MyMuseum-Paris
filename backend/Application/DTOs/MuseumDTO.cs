using Backend.Domain.Entities;

namespace Backend.Application.DTOs
{
    public class MuseumDTO
    {
        public int MuseumId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string[] IndoorOrOutdoor { get; set; } = Array.Empty<string>();
        public Accessibility Accessibility { get; set; }
        public bool AudioGuide { get; set; }
        public bool GuidedTours { get; set; }
        public Languages Languages { get; set; }
        public required MuseumSchedule MuseumSchedule { get; set; }
        public int? CityId { get; set; }
    }
}
