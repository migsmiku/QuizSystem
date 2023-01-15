namespace OnlineQuiz.DAL
{
    using OnlineQuiz.Models;

    public interface IAccountDAL
    {
        void CreateUser(Users user);
        Users Login(string username, string password);
    }
}