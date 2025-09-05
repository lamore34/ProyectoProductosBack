using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Productos.Infrastructure.DBContext
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string getConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection CreateConnection() =>
            new SqlConnection(getConnectionString());
    }
}
