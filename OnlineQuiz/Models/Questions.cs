namespace OnlineQuiz.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.Build.ObjectModelRemoting;

    public class Questions
    {
        [Key]
        public int QuestionId { get; set; }
        public int QuizCategoryId { get; set; }
        public string? QuestionText { get; set; }
        public int QuestionType { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool QuestionStatus { get; set; }

        public virtual ICollection<Options>? Options { get; set; }

        public virtual ICollection<QuizQuestions>? QuizQuestions { get; set; }
    }
}
