using Backend.Domain.Enums;

namespace Backend.Domain.Entities
{
    public class MuseumLanguage
    {
        public int MuseumId { get; set; }
        public Museum Museum { get; set; } = null!;

        public Language Language { get; set; }
    }
}