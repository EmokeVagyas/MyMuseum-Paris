namespace Backend.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<UserQuestionnaireResponse> UserQuestionnaireResponses { get; set; }
        public List<UserTravelDay> UserTravelDays { get; set; }
        public List<GroupQuestionnaireResponse> GroupQuestionnaireResponses { get; set; }
    }
}
