namespace OnlineQuiz.Models
{
    public class QuizQuestions
    {
        public int QuizQuestionId { get; set; }
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public int SelectedOptionId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
