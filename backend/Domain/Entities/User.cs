using System.ComponentModel.DataAnnotations;

namespace Backend.Domain.Entities
{
    public class User
    {
        [Key]
        public required int UserID { get; set; }
        public required string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        // @TOOD: Re-think this
        // public required List<UserTravelDay> UserTravelDays { get; set; }
        // public required List<UserQuestionnaireResponse> UserQuestionnaireResponses { get; set; }
        // public required List<GroupQuestionnaireResponse> GroupQuestionnaireResponses { get; set; }
    }
}
