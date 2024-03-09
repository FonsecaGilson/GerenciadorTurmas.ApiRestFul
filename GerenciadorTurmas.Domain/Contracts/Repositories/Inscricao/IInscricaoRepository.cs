using GerenciadorTurmas.Domain.Entities;

namespace GerenciadorTurmas.Domain.Contracts.Repositories.Inscricao
{
    public interface IInscricaoRepository
    {
        Task<int> Inserir(AlunoTurmaEntity inscricao);

        Task Alterar(AlunoTurmaEntity inscricao);

        Task Inativar(int id);

        Task<IEnumerable<AlunoTurmaEntity>> Listar();

        Task<AlunoTurmaEntity> ConsultarPorId(int id);
    }
}
