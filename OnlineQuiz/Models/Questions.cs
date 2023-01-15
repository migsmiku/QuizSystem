namespace OnlineQuiz.Models
{
    public class Questions
    {
        public int QuestionId { get; set; }
        public int QuizCategoryId { get; set; }
        public string? QuestionText { get; set; }
        public int QuestionType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
