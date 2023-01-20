namespace OnlineQuiz.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using OnlineQuiz.Models;

    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

        public DbSet<Options> Options { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<QuizCategories> QuizCategory { get; set; }
        public DbSet<QuizQuestions> QuizQuestions { get; set; }
        public DbSet<QuizSubmissions> QuizSubmissions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Quizzes> Quizzes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuizCategories>().ToTable("QuizCategory");

            _ = modelBuilder.Entity<QuizQuestions>().HasKey(qq => new { qq.QuizId, qq.QuestionId });

            _ = modelBuilder.Entity<QuizQuestions>()
                        .HasOne(qq => qq.Questions)
                        .WithMany(q => q.QuizQuestions)
                        .HasForeignKey(q => q.QuestionId);

            _ = modelBuilder.Entity<QuizQuestions>()
                       .HasOne(qq => qq.Quizzes)
                       .WithMany(q => q.QuizQuestions)
                       .HasForeignKey("QuizId");

            _ = modelBuilder.Entity<Questions>()
                            .HasMany(o => o.Options)
                            .WithOne(q => q.Questions)
                            .HasForeignKey(o => o.QuestionId);
        }
    }
}
