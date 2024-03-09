using GerenciadorTurmas.Domain.Contracts.Repositories.Inscricao;
using GerenciadorTurmas.Domain.Contracts.UseCases.Inscriao;
using GerenciadorTurmas.Domain.Entities;

namespace GerenciadorTurmas.Application.UseCases
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
            await _inscricaoRepository.Alterar(inscricao);
        }

        public async Task<int> Inserir(AlunoTurmaEntity inscricao)
        {
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
    }
}
