namespace OnlineQuiz.DAO
{
    using System.Data.SqlClient;
    using System.Text;
    using System.Transactions;
    using OnlineQuiz.Models;

    public class AccountDAO : DAOBase, IAccountDAO
    {
        public AccountDAO(IConfiguration config) : base(config)
        {
        }

        public void CreateUser(User user)
        {
            using TransactionScope transactionScope = new();
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Users (UserName, FirstName, LastName, Email, DateOfBirth, [Password], UserRoleId) VALUES (@UserName, @FirstName, @LastName, @Email, @DateOfBirth, @Password, @UserRoleId);", conn);
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@UserName", user.UserName),
                    new SqlParameter("@FirstName", user.FirstName),
                    new SqlParameter("@LastName", user.LastName),
                    new SqlParameter("@Email", user.Email),
                    new SqlParameter("@DateOfBirth", user.DateOfBirth),
                    new SqlParameter("@Password", user.Password),
                    new SqlParameter("@UserRoleId", user.UserRoleId)
                });
                command.ExecuteNonQuery();
                transactionScope.Complete();
            }
        }

        public bool Login(string username, string password)
        {
            using SqlConnection conn = Connection;
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Users", conn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(reader.GetOrdinal("username")) == username && reader.GetString(reader.GetOrdinal("password")) == password)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
