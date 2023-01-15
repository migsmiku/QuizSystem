namespace OnlineQuiz.DAL
{
    using System.Data.SqlClient;

    public class DALBase
    {
        private readonly IConfiguration _config;

        public DALBase(IConfiguration config)
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