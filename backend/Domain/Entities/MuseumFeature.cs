using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class MuseumFeature
    {
        public int Id { get; set; }
        public required string FeatureType { get; set; }


        [InverseProperty("MuseumFeature")]
        public List<MuseumFeatureOption> MuseumFeatureOptions { get; set; } = [];
    }
}
