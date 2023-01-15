namespace OnlineQuiz.Models
{
    public class QuizSubmissions
    {
        public int QuizSubmissionId { get; set; }
        public int QuizId { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int Score { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
