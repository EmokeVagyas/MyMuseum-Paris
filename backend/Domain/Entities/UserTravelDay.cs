namespace Backend.Domain.Entities
{
    public class UserTravelDay
    {
        public int UserID { get; set; }
        public DateTime TravelDay { get; set; }
        public User? User { get; set; }
    }
}
