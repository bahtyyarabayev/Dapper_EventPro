using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperActivityProject.Context
{
    public class ActivityContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ActivityContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("connectionkey");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
