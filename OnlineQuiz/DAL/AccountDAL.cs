namespace OnlineQuiz.DAL
{
    using System.Data.SqlClient;
    using System.Transactions;
    using OnlineQuiz.Models;

    public class AccountDAL : DALBase, IAccountDAL
    {
        public AccountDAL(IConfiguration config) : base(config)
        {
        }

        public void CreateUser(Users user)
        {
            using TransactionScope transactionScope = new();
            using SqlConnection conn = Connection;
            conn.Open();
            SqlCommand command = new("INSERT INTO Users (UserName, FirstName, LastName, Email, DateOfBirth, [Password], UserRoleId) VALUES (@UserName, @FirstName, @LastName, @Email, @DateOfBirth, @Password, @UserRoleId);", conn);
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
            _ = command.ExecuteNonQuery();
            transactionScope.Complete();
        }

        public Users? Login(string userName, string password)
        {
            try
            {
                using SqlConnection conn = Connection;
                conn.Open();
                SqlCommand command = new("SELECT * FROM Users WHERE UserName = @username AND Password = @password;", conn);
                command.Parameters.AddRange(new SqlParameter[]
                    {
                    new SqlParameter("@UserName", userName),
                    new SqlParameter("@Password", password),
                    });
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Users user = new()
                    {
                        UserID = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        FirstName = reader.GetString(2),
                        LastName = reader.GetString(3),
                        Email = reader.GetString(4),
                        DateOfBirth = reader.GetDateTime(5),
                        Password = reader.GetString(6),
                        UserRoleId = reader.GetInt32(7)
                    };
                    return user;
                }
            }
            catch (Exception)
            {

                return null;
            }

            return null;
        }
    }
}
