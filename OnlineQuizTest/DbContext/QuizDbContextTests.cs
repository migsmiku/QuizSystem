namespace OnlineQuizTest.DbContext
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using OnlineQuiz.DbContext;
    using OnlineQuiz.Models;

    public class QuizDbContextTests
    {
        private const string _defaultDbString= "Persist Security Info=False;User ID=SA;Password=PwdToExpress2019;Initial Catalog=quiz;Server=localhost;TrustServerCertificate=True";

        [Fact]
        public void TestDbContextOptions()
        {
            var connection = new SqlConnection(_defaultDbString);
            connection.Open();

            var options = new DbContextOptionsBuilder<QuizDbContext>()
                .UseSqlServer(connection)
                .Options;

            using (var context = new QuizDbContext(options))
            {
                Assert.NotNull(context.Options);
            }
        }

        [Fact]
        public void TestDbSets()
        {
            var connection = new SqlConnection(_defaultDbString);
            connection.Open();

            var options = new DbContextOptionsBuilder<QuizDbContext>()
                .UseSqlServer(connection)
                .Options;

            using (var context = new QuizDbContext(options))
            {
                Assert.NotNull(context.Options);
                Assert.NotNull(context.Users);
                Assert.NotNull(context.Questions);
                Assert.NotNull(context.QuizCategories);
                Assert.NotNull(context.QuizQuestions);
                Assert.NotNull(context.QuizSubmissions);
                Assert.NotNull(context.Quizzes);
                Assert.NotNull(context.Options);
            }
        }

        [Fact]
        public void TestOnModelCreating()
        {
            var connection = new SqlConnection(_defaultDbString);
            connection.Open();

            var options = new DbContextOptionsBuilder<QuizDbContext>()
                .UseSqlServer(connection)
                .Options;

            using (var context = new QuizDbContext(options))
            {
                context.Database.EnsureCreated();

                var users = context.Model.FindEntityType(typeof(Users));
                var property = users.FindProperty("UserStatus");
                Assert.Equal("BIT", property.GetColumnType());

                var questions = context.Model.FindEntityType(typeof(Questions));
                var property2 = questions.FindProperty("QuestionStatus");
                Assert.Equal("BIT", property2.GetColumnType());
            }
        }
    }
}
