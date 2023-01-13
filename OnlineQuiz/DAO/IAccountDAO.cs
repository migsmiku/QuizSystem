namespace OnlineQuiz.DAO
{
    using OnlineQuiz.Models;

    public interface IAccountDAO
    {
        void CreateUser(User user);
        bool Login(string username, string password);
    }
}