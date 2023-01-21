namespace OnlineQuiz.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class QuizSubmissions
    {
        [Key]
        public int QuizSubmissionId { get; set; }
        public int QuizId { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int Score { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("QuizId")]
        public virtual Quizzes Quizzes { get; set; }
        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
    }
}
