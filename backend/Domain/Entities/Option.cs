using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    public class Option
    {
        [Key]
        public int Id { get; set; }
        public required string Text { get; set; }

        // Relations
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; } = null!;
    }
}

