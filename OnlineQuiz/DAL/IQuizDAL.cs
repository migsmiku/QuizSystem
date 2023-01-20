namespace OnlineQuiz.DAL
{
    using System;
    using System.Collections.Generic;
    using OnlineQuiz.Models;

    public interface IQuizDAL
    {
        QuizViewModel CreateQuiz(int quizCategoryId, string? userId, int userId1);
        IEnumerable<QuizCategories> GetQuizCategory();
        QuizViewModel GetQuizViewModel(int? quizId);
        void SubmitQuiz(int? quizId, int userId, List<QuizQuestions> quizQuestions, DateTime endTime);
    }
}