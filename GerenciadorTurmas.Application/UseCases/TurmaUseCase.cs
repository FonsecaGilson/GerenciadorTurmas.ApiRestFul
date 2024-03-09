using GerenciadorTurmas.Domain.Contracts.Repositories.Aluno;
using GerenciadorTurmas.Domain.Contracts.Repositories.Turma;
using GerenciadorTurmas.Domain.Contracts.UseCases.Aluno;
using GerenciadorTurmas.Domain.Contracts.UseCases.Turma;
using GerenciadorTurmas.Domain.Entities;
namespace GerenciadorTurmas.Application.UseCases
{
    public class TurmaUseCase : ITurmaUseCase
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaUseCase(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task Alterar(TurmaEntity turma)
        {
            await _turmaRepository.Alterar(turma);
        }

        public async Task<int> Inserir(TurmaEntity turma)
        {
            return await _turmaRepository.Inserir(turma);
        }

        public async Task Inativar(int id)
        {
            await _turmaRepository.Inativar(id);
        }
        public async Task<IEnumerable<TurmaEntity>> Listar()
        {
            return await _turmaRepository.Listar();
        }

        public async Task<TurmaEntity> ConsultarPorId(int id)
        {
            return await _turmaRepository.ConsultarPorId(id);
        }
    }
}
