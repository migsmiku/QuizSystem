namespace OnlineQuiz.Models
{
    using System.Collections.Generic;

    public class QuizViewModel
    {
        public IList<Questions>? Questions { get; set; }

        public IList<Options>? Options { get; set; }
        public int QuizId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public List<QuizQuestions>? QuizQuestions { get; set; }

        public QuizSubmissions? QuizSubmissions { get; set; }
        public int CurrentQuestionIndex { get; set; } = 0;
        public string? QuizName { get; set; }
    }
}
