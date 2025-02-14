using Backend.Domain.Enums;

namespace Backend.Application.DTOs.Museum
{
    public class GetMuseumDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string Description { get; set; }
        public MuseumEnvironment Environment { get; set; }
    }
}
