using System.Data;

namespace GerenciadorTurmas.Infrastructure.DbContext
{
    public interface IDbContext
    {
        IDbConnection CreateConnection();
    }
}
