namespace OnlineQuiz.Models
{
    using System.Collections.Generic;

    public class AdminViewModel
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public ICollection<Questions>? Questions { get; set; }

        public ICollection<Options>? Options { get; set; }

        public ICollection<QuizQuestions>? QuizQuestions { get; set; }

        public IQueryable<QuizSubmissions>? QuizSubmissions { get; set; }

        public ICollection<Quizzes>? Quizzes { get; set; }

        public IQueryable<Users>? Users { get; set; }
        public string CategoryFilter { get; internal set; }
        public string UserFilter { get; internal set; }
    }
}
