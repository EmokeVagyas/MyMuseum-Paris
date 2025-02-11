using Backend.Domain.Enums;

namespace Backend.Domain.Entities
{
    public class MuseumAccessibility
    {
        public int MuseumId { get; set; }
        public Museum Museum { get; set; } = null!;

        public Accessibility Accessibility { get; set; }
    }
}