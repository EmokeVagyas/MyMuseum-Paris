using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    [Table("countries")]
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public required string Name { get; set; }

        // Relations
        public List<City> Cities { get; set; } = [];
    }
}
