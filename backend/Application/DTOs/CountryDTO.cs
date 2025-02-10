namespace Backend.Application.DTOs
{
    public class CountryDTO
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<string>? Cities { get; set; }
    }
}
