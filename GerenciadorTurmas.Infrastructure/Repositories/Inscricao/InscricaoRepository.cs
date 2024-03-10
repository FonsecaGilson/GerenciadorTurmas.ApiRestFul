using Dapper;
using BancoDadosTest.Domain.Contracts.Repositories.Inscricao;
using BancoDadosTest.Domain.Entities;
using BancoDadosTest.Infrastructure.DbContext;
using System.Threading.Tasks;

namespace BancoDadosTest.Infrastructure.Repositories.Inscricao
{
    public class InscricaoRepository : IInscricaoRepository
    {
        private readonly IDbContext _dbContext;

        public InscricaoRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Inserir(AlunoTurmaEntity inscricao)
        {
            var query = @"  Insert Into Aluno_Turma ( Aluno_Id, Turma_Id )
                            Values ( @AlunoId, @TurmaId )
                            Select Scope_Identity() ";

            var parameters = new DynamicParameters();

            parameters.Add("AlunoId", inscricao.AlunoId, System.Data.DbType.Int32);
            parameters.Add("TurmaId", inscricao.TurmaId, System.Data.DbType.Int32);

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<int>(query, parameters);
        }

        public async Task Alterar(AlunoTurmaEntity inscricao)
        {
            var query = @"  Update Aluno_Turma 
                            Set Aluno_Id = @AlunoId, 
                                Turma_Id = @TurmaId 
                            Where Id = @Id ";

            var parameters = new DynamicParameters();

            parameters.Add("Id", inscricao.Id, System.Data.DbType.Int32);
            parameters.Add("AlunoId", inscricao.AlunoId, System.Data.DbType.Int32);
            parameters.Add("TurmaId", inscricao.TurmaId, System.Data.DbType.Int32);

            using var connection = _dbContext.CreateConnection();

            await connection.ExecuteAsync(query, parameters);
        }

        public async Task Inativar(int id)
        {
            var query = @"  Update Aluno_Turma 
                            Set IsDeleted = 1
                            Where Id = @Id ";

            var parameters = new DynamicParameters();

            parameters.Add("Id", id, System.Data.DbType.Int32);

            using var connection = _dbContext.CreateConnection();

            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<AlunoTurmaEntity>> Listar()
        {
            var query = @"  Select Id, Aluno_Id As AlunoId, Turma_Id As TurmaId                
                            From Aluno_Turma 
                            Where IsDeleted = 0 ";

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryAsync<AlunoTurmaEntity>(query);
        }

        public async Task<AlunoTurmaEntity> ConsultarPorId(int id)
        {
            var query = @"  Select Id, Aluno_Id As AlunoId, Turma_Id As TurmaId 
                            From Aluno_Turma 
                            Where IsDeleted = 0 And Id = @Id ";

            var parameters = new DynamicParameters();

            parameters.Add("Id", id, System.Data.DbType.Int32);

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryFirstAsync<AlunoTurmaEntity>(query, parameters);
        }

        public async Task<bool> VerificarExistenciaInscricao(int alunoId, int turmaId, int? id)
        {
            var query = @" Select Case
                                        When Exists
                                            (
                                                Select Top 1 1
                                                From   Aluno_Turma
                                                Where  Aluno_Id = @alunoId And Turma_Id = @turmaId
                                                        And IsDeleted = 0
                                                        And ((Id <> @id And @id Is Not Null) Or @id Is Null)
                                            )
                                          Then Cast(1 As Bit)
                                      Else Cast(0 As Bit)
                                  End ";

            var parameters = new DynamicParameters();

            parameters.Add("alunoId", alunoId, System.Data.DbType.Int64);
            parameters.Add("turmaId", turmaId, System.Data.DbType.Int64);
            parameters.Add("id", id, System.Data.DbType.Int64);

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryFirstAsync<bool>(query, parameters);
        }
    }
}
