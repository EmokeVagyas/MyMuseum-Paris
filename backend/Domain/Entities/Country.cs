namespace Backend.Domain.Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        public required string Name { get; set; }
        public List<City>? Cities { get; set; }
    }
}
