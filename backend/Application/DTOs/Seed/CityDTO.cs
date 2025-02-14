namespace Backend.Application.DTOs.Seed
{
    public class CityDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = null!;

        public int CountryId { get; set; }
    }
}
