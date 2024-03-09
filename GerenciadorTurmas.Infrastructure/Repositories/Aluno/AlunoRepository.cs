using Dapper;
using GerenciadorTurmas.Domain.Contracts.Repositories.Aluno;
using GerenciadorTurmas.Domain.Entities;
using GerenciadorTurmas.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurmas.Infrastructure.Repositories.Aluno
{
    public class AlunoRepository: IAlunoRepository
    {
        private readonly IDbContext _dbContext;

        public AlunoRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Inserir(AlunoEntity aluno)
        {
            var query = " Select 1";

            var parameters = new DynamicParameters();

            parameters.Add("Nome", aluno.Nome, System.Data.DbType.String);

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<int>(query, parameters);
        }
    }
}
