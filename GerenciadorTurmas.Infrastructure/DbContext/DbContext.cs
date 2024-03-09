using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GerenciadorTurmas.Infrastructure.DbContext
{
    public class DbContext : IDbContext
    {
        private readonly string? _connectionString;

        public DbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServer");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
