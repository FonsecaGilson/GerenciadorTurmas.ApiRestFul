using Dapper;
using GerenciadorTurmas.Domain.Contracts.Repositories.Turma;
using GerenciadorTurmas.Domain.Entities;
using GerenciadorTurmas.Infrastructure.DbContext;


namespace GerenciadorTurmas.Infrastructure.Repositories.Turma
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly IDbContext _dbContext;

        public TurmaRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Inserir(TurmaEntity turma)
        {
            var query = @"  Insert Into Turma ( Turma, Ano )
                            Values ( @Turma, @Ano )
                            Select Scope_Identity() ";

            var parameters = new DynamicParameters();

            parameters.Add("Turma", turma.Turma, System.Data.DbType.String);
            parameters.Add("Ano", turma.Ano, System.Data.DbType.Int32);

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<int>(query, parameters);
        }

        public async Task Alterar(TurmaEntity turma)
        {
            var query = @"  Update Turma 
                            Set Turma = @Turma, 
                                Ano = @Ano
                            Where Id = @Id ";

            var parameters = new DynamicParameters();

            parameters.Add("Id", turma.Id, System.Data.DbType.Int32);
            parameters.Add("Turma", turma.Turma, System.Data.DbType.String);
            parameters.Add("Ano", turma.Ano, System.Data.DbType.Int32);

            using var connection = _dbContext.CreateConnection();

            await connection.ExecuteAsync(query, parameters);
        }

        public async Task Inativar(int id)
        {
            var query = @"  Update Turma 
                            Set Turma = Turma
                            Where Id = @Id ";

            var parameters = new DynamicParameters();

            parameters.Add("Id", id, System.Data.DbType.Int32);

            using var connection = _dbContext.CreateConnection();

            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<TurmaEntity>> Listar()
        {
            var query = @"  Select Id, Turma, Ano
                            From Turma 
                            Where Id = Id ";

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryAsync<TurmaEntity>(query);
        }

        public async Task<TurmaEntity> ConsultarPorId(int id)
        {
            var query = @"  Select Id, Turma, Ano
                            From Turma 
                            Where Id = @Id ";

            var parameters = new DynamicParameters();

            parameters.Add("Id", id, System.Data.DbType.Int32);

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryFirstAsync<TurmaEntity>(query, parameters);
        }
    }
}
