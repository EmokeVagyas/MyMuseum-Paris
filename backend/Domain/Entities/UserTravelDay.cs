using Newtonsoft.Json;

namespace Backend.Domain.Entities
{
    public class UserTravelDay
    {
        public int UserID { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateTime TravelDay { get; set; }
        public User? User { get; set; }
    }
}
