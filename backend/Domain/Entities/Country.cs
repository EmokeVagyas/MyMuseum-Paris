using System.ComponentModel.DataAnnotations;

namespace Backend.Domain.Entities
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public required string Name { get; set; }

        // Relations
        public List<City> Cities { get; set; } = [];
    }
}
