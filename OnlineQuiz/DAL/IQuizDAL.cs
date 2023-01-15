namespace OnlineQuiz.DAL
{
    using System.Collections.Generic;
    using OnlineQuiz.Models;

    public interface IQuizDAL
    {
        QuizViewModel CreateQuiz(int quizCategoryId, string? userId, int userId1);
        IEnumerable<QuizCategory> GetQuizCategory();
        QuizViewModel GetQuizViewModel(int? quizId);
    }
}