using GerenciadorTurmas.Domain.Entities;

namespace GerenciadorTurmas.Domain.Contracts.UseCases.Inscriao
{
    public interface IInscricaoUseCase
    {
        Task<int> Inserir(AlunoTurmaEntity inscricao);

        Task Alterar(AlunoTurmaEntity inscricao);

        Task Inativar(int id);

        Task<IEnumerable<AlunoTurmaEntity>> Listar();

        Task<AlunoTurmaEntity> ConsultarPorId(int id);

        Task VerificarExistenciaInscricao(int alunoId, int turmaId, int? id = null);
    }
}
