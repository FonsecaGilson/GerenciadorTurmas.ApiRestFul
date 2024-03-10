using BancoDadosTest.Application.CustonException;
using BancoDadosTest.Domain.Contracts.Repositories.Inscricao;
using BancoDadosTest.Domain.Contracts.UseCases.Inscriao;
using BancoDadosTest.Domain.Entities;

namespace BancoDadosTest.Application.UseCases
{
    public class InscricaoUseCase : IInscricaoUseCase
    {
        private readonly IInscricaoRepository _inscricaoRepository;

        public InscricaoUseCase(IInscricaoRepository inscricaoRepository)
        {
            _inscricaoRepository = inscricaoRepository;
        }

        public async Task Alterar(AlunoTurmaEntity inscricao)
        {
            await VerificarExistenciaInscricao(inscricao.AlunoId, inscricao.TurmaId, inscricao.Id);

            await _inscricaoRepository.Alterar(inscricao);
        }

        public async Task<int> Inserir(AlunoTurmaEntity inscricao)
        {
            await VerificarExistenciaInscricao(inscricao.AlunoId, inscricao.TurmaId);

            return await _inscricaoRepository.Inserir(inscricao);
        }

        public async Task Inativar(int id)
        {
            await _inscricaoRepository.Inativar(id);
        }
        
        public async Task<IEnumerable<AlunoTurmaEntity>> Listar()
        {
            return await _inscricaoRepository.Listar();
        }

        public async Task<AlunoTurmaEntity> ConsultarPorId(int id)
        {
            return await _inscricaoRepository.ConsultarPorId(id);
        }

        public async Task VerificarExistenciaInscricao(int alunoId, int turmaId, int? id = null)
        {
            var turmaExistente = await _inscricaoRepository.VerificarExistenciaInscricao(alunoId, turmaId, id);

            if (turmaExistente)
            {
                throw new RegraNegocioException($"Esse aluno já esta cadastrado nesse turma.");
            }
        }
    }
}
