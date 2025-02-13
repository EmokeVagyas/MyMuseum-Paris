using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    [Table("user_travel_days")]
    public class UserTravelDay
    {
        // I don't think this entity is correct. Let's rethink ti once more before using please.
        public int UserId { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateTime TravelDay { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
