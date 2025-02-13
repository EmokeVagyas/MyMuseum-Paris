using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    [Table("museum_features")]
    public class MuseumFeature
    {
        [Key]
        public int Id { get; set; }
        public required string FeatureType { get; set; }


        [InverseProperty("MuseumFeature")]
        public List<MuseumFeatureOption> MuseumFeatureOptions { get; set; } = [];
    }
}
