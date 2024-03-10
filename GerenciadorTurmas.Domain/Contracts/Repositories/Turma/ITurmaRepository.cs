using BancoDadosTest.Domain.Entities;

namespace BancoDadosTest.Domain.Contracts.Repositories.Turma
{
    public interface ITurmaRepository
    {
        Task<int> Inserir(TurmaEntity aluno);

        Task Alterar(TurmaEntity aluno);

        Task Inativar(int id);

        Task<IEnumerable<TurmaEntity>> Listar();

        Task<TurmaEntity> ConsultarPorId(int id);

        Task<bool> VerificarExistenciaTurma(string turma, int? id);
    }
}
