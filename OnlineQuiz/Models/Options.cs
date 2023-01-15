namespace OnlineQuiz.Models
{
    public class Options
    {
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
        public string? OptionText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
