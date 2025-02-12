namespace Backend.Application.DTOs
{
    public class MuseumFeatureAssociationDto
    {
        public int MuseumId { get; set; }

        public List<int> MuseumFeatureOptionIds { get; set; } = [];
    }
}
