using BancoDadosTest.Application.CustonException;
using BancoDadosTest.Domain.Contracts.Repositories.Turma;
using BancoDadosTest.Domain.Contracts.UseCases.Turma;
using BancoDadosTest.Domain.Entities;
namespace BancoDadosTest.Application.UseCases
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
            await VerificarExistenciaTurma(turma.Turma, turma.Id);

            await _turmaRepository.Alterar(turma);
        }

        public async Task<int> Inserir(TurmaEntity turma)
        {
            await VerificarExistenciaTurma(turma.Turma);

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

        public async Task VerificarExistenciaTurma(string turma, int? id = null)
        {
            var turmaExistente =  await _turmaRepository.VerificarExistenciaTurma(turma, id);

            if (turmaExistente)
            {
                throw new RegraNegocioException($"Já existe uma turma cadastrada com o nome {turma}.");
            }
        }
    }
}
