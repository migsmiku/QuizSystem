namespace OnlineQuiz.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class QuizCategories
    {
        [Key]
        public int QuizCategoryId { get; set; }
        public string? QuizCategoryName { get; set; }
        [InverseProperty("QuizCategories")]
        public virtual ICollection<Quizzes> Quizzes { get; set; }
    }
}
