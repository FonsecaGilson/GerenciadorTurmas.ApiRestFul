using BancoDadosTest.Domain.Contracts.Repositories.Turma;
using BancoDadosTest.Domain.Entities;
using BancoDadosTest.Infrastructure.DbContext;
using Dapper;


namespace BancoDadosTest.Infrastructure.Repositories.Turma
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
                            Set IsDeleted = 1
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
                            Where IsDeleted = 0 ";

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryAsync<TurmaEntity>(query);
        }

        public async Task<TurmaEntity> ConsultarPorId(int id)
        {
            var query = @"  Select Id, Turma, Ano
                            From Turma 
                            Where IsDeleted = 0 And Id = @Id ";

            var parameters = new DynamicParameters();

            parameters.Add("Id", id, System.Data.DbType.Int32);

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryFirstAsync<TurmaEntity>(query, parameters);
        }

        public async Task<bool> VerificarExistenciaTurma(string turma, int? id)
        {
            var query = @" Select Case
                                        When Exists
                                            (
                                                Select Top 1 1
                                                From   Turma
                                                Where  Turma = @turma
                                                        And IsDeleted = 0
                                                        And ((Id <> @Id And @Id Is Not Null) Or @Id Is Null)
                                            )
                                          Then Cast(1 As Bit)
                                      Else Cast(0 As Bit)
                                  End ";

            var parameters = new DynamicParameters();

            parameters.Add("turma", turma, System.Data.DbType.String);
            parameters.Add("id", id, System.Data.DbType.Int64);

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryFirstAsync<bool>(query, parameters);
        }
    }
}
