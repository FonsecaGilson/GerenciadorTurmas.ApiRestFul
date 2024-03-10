using BancoDadosTest.Domain.Entities;

namespace BancoDadosTest.Domain.Contracts.Repositories.Inscricao
{
    public interface IInscricaoRepository
    {
        Task<int> Inserir(AlunoTurmaEntity inscricao);

        Task Alterar(AlunoTurmaEntity inscricao);

        Task Inativar(int id);

        Task<IEnumerable<AlunoTurmaEntity>> Listar();

        Task<AlunoTurmaEntity> ConsultarPorId(int id);

        Task<bool> VerificarExistenciaInscricao(int alunoId, int turmaId, int? id);
    }
}
