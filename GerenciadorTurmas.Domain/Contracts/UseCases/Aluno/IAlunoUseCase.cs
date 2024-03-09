using GerenciadorTurmas.Domain.Entities;

namespace GerenciadorTurmas.Domain.Contracts.UseCases.Aluno
{
    public interface IAlunoUseCase
    {
        Task<int> Inserir(AlunoEntity aluno);

        Task Alterar(AlunoEntity aluno);

        Task Inativar(int id);

        Task<IEnumerable<AlunoEntity>> Listar();

        Task<AlunoEntity> ConsultarPorId(int id);
    }
}
