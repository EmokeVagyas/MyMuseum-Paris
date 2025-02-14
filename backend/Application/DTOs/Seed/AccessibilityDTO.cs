using Backend.Domain.Enums;

namespace Backend.Application.DTOs.Seed
{
    public class AccessibilityDto
    {
        public int MuseumId { get; set; }
        public Accessibility Accessibility { get; set; }
    }
}
