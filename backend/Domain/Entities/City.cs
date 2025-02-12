namespace Backend.Domain.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public required string Name { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
