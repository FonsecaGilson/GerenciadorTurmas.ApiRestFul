using System.Data;

namespace BancoDadosTest.Infrastructure.DbContext
{
    public interface IDbContext
    {
        IDbConnection CreateConnection();
    }
}
