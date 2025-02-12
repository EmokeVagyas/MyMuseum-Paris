using Backend.Domain.Entities;
using Backend.Domain.Enums;

namespace Backend.Application.DTOs
{
    public class MuseumDto
    {
        public int MuseumId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public MuseumEnvironment Environment { get; set; }
        public required List<Accessibility> Accessibilities { get; set; }
        public required List<Language> Languages { get; set; }
        public bool GuidedTours { get; set; }
        public bool AudioGuide { get; set; }

        public int CityId { get; set; }
    }
}
