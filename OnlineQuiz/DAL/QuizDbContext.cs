namespace OnlineQuiz.DAL
{
    using Microsoft.EntityFrameworkCore;

    public class QuizDbContext : DbContext, IQuizDbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }
    }
}
