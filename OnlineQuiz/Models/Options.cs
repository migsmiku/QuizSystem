namespace OnlineQuiz.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Options
    {
        [Key]
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
        public string? OptionText { get; set; }
        public bool IsCorrect { get; set; }

        public Questions Questions { get; set; }
    }
}
