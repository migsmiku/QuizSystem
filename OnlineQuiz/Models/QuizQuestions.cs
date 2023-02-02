namespace OnlineQuiz.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class QuizQuestions
    {
        public int QuizQuestionId { get; set; }
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public int SelectedOptionId { get; set; }
        public DateTime CreatedDate { get; set; }

        [InverseProperty("QuizQuestions")]
        public virtual Quizzes? Quizzes { get; set; }

        public virtual Questions? Questions { get; set; }
    }
}
