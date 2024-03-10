using GerenciadorTurmas.Domain.Entities;

namespace GerenciadorTurmas.Domain.Contracts.UseCases.Turma
{
    public interface ITurmaUseCase
    {
        Task<int> Inserir(TurmaEntity aluno);

        Task Alterar(TurmaEntity aluno);

        Task Inativar(int id);

        Task<IEnumerable<TurmaEntity>> Listar();

        Task<TurmaEntity> ConsultarPorId(int id);

        Task VerificarExistenciaTurma(string turma, int? id = null);
    }
}
