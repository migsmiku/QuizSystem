namespace OnlineQuiz.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Quizzes
    {
        [Key]
        public int QuizId { get; set; }

        public string QuizName { get; set; }
                
        public int QuizCategoryId { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("QuizId")]
        public virtual ICollection<QuizQuestions>? QuizQuestions { get; set; }

        [ForeignKey("QuizCategoryId")]
        public virtual QuizCategories? QuizCategories { get; set; }

        [InverseProperty("Quizzes")]
        public virtual QuizSubmissions? QuizSubmissions { get; set; }
    }
}
