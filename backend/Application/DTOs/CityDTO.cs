namespace Backend.Application.DTOs
{
    public class CityDTO
    {
        public int CityId { get; set; }
        public string Name { get; set; } = null!;
        public int CountryId { get; set; }
        public string CountryName { get; set; } = null!;
    }
}
