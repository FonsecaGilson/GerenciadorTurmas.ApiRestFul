using BancoDadosTest.Domain.Contracts.Repositories.Aluno;
using BancoDadosTest.Domain.Entities;
using BancoDadosTest.Infrastructure.DbContext;
using BancoDadosTest.Infrastructure.Extensions;
using Dapper;

namespace BancoDadosTest.Infrastructure.Repositories.Aluno
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IDbContext _dbContext;

        public AlunoRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Inserir(AlunoEntity aluno)
        {
            var query = @"  Insert Into Aluno ( Nome, Usuario, Senha )
                            Values ( @Nome, @Usuario, @Senha )
                            Select Scope_Identity() ";

            var parameters = new DynamicParameters();

            parameters.Add("Nome", aluno.Nome, System.Data.DbType.String);
            parameters.Add("Usuario", aluno.Usuario, System.Data.DbType.String);
            parameters.Add("Senha", aluno.Senha.HashPassword(), System.Data.DbType.String);

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<int>(query, parameters);
        }

        public async Task Alterar(AlunoEntity aluno)
        {
            var query = @"  Update Aluno 
                            Set Nome = @Nome, 
                                Usuario = @Usuario, 
                                Senha = @Senha
                            Where Id = @Id ";

            var parameters = new DynamicParameters();

            parameters.Add("Id", aluno.Id, System.Data.DbType.Int32);
            parameters.Add("Nome", aluno.Nome, System.Data.DbType.String);
            parameters.Add("Usuario", aluno.Usuario, System.Data.DbType.String);
            parameters.Add("Senha", aluno.Senha.HashPassword(), System.Data.DbType.String);

            using var connection = _dbContext.CreateConnection();

            await connection.ExecuteAsync(query, parameters);
        }

        public async Task Inativar(int id)
        {
            var query = @"  Update Aluno 
                            Set IsDeleted = 1
                            Where Id = @Id ";

            var parameters = new DynamicParameters();

            parameters.Add("Id", id, System.Data.DbType.Int32);

            using var connection = _dbContext.CreateConnection();

            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<AlunoEntity>> Listar()
        {
            var query = @"  Select Id, Nome, Usuario, '' As Senha                 
                            From Aluno 
                            Where IsDeleted = 0 ";

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryAsync<AlunoEntity>(query);
        }

        public async Task<AlunoEntity> ConsultarPorId(int id)
        {
            var query = @"  Select Id, Nome, Usuario, '' As Senha  
                            From Aluno 
                            Where IsDeleted = 0 And Id = @Id ";

            var parameters = new DynamicParameters();

            parameters.Add("Id", id, System.Data.DbType.Int32);

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryFirstAsync<AlunoEntity>(query, parameters);
        }
    }
}
