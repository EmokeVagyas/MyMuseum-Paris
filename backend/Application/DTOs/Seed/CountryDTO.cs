namespace Backend.Application.DTOs.Seed
{
    public class CountryDto
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public ICollection<CityDto> Cities { get; set; } = [];
    }
}
