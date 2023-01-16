namespace OnlineQuiz.DAL
{
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Primitives;
    using OnlineQuiz.Models;

    public class FeedbackDAL : DALBase, IFeedbackDAL
    {
        public FeedbackDAL(IConfiguration config) : base(config)
        {
        }

        public int SaveFeedback(int rating, string feedbackText)
        {
            using(var conn = Connection)
            {
                conn.Open();
                using(SqlCommand command = new SqlCommand("INSERT INTO Feedback (Rating, FeedbackText) VALUES (@Rating, @FeedbackText)", conn))
                {
                    command.Parameters.AddWithValue("@Rating", rating);
                    command.Parameters.AddWithValue("@FeedbackText", feedbackText);
                    var rowInserted = command.ExecuteNonQuery();
                    return rowInserted;
                }
            }
        }
    }
}
