using GerenciadorTurmas.Domain.Entities;

namespace GerenciadorTurmas.Domain.Contracts.Repositories.Aluno
{
    public interface IAlunoRepository
    {
        Task<int> Inserir(AlunoEntity aluno);

        Task Alterar(AlunoEntity aluno);

        Task Inativar(int id);

        Task<IEnumerable<AlunoEntity>> Listar();

        Task<AlunoEntity> ConsultarPorId(int id);
    }
}
