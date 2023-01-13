namespace OnlineQuiz.DAO
{
    using System.Data.SqlClient;

    public class DAOBase
    {
        private readonly IConfiguration _config;

        public DAOBase(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                string connectionString = _config.GetConnectionString("Default");

                // Return a new SqlConnection instance
                return new SqlConnection(connectionString);
            }
        }
    }
}