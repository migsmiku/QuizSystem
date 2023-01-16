namespace OnlineQuiz.DAL
{
    using Microsoft.Extensions.Primitives;

    public interface IFeedbackDAL
    {
        int SaveFeedback(int rating, string feedbackText);
    }
}