using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    [Table("opening_hours")]
    public class OpeningHour
    {
        [Key]
        public int OpeningHourId { get; set; }
        public int DayOfWeek { get; set; }

        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly? OpeningTime { get; set; }

        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly? ClosingTime { get; set; }

        public bool IsFree { get; set; }
        public bool IsClosed { get; set; }

        // Relationships
        public int? ExceptionalDayId { get; set; }
        [ForeignKey("ExceptionalDayId")]
        public ExceptionalDay? ExceptionalDay { get; set; }

    }
}