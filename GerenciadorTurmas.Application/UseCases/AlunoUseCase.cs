using GerenciadorTurmas.Domain.Contracts.Repositories.Aluno;
using GerenciadorTurmas.Domain.Contracts.UseCases.Aluno;
using GerenciadorTurmas.Domain.Entities;

namespace GerenciadorTurmas.Application.UseCases
{
    public class AlunoUseCase : IAlunoUseCase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task Alterar(AlunoEntity aluno)
        {
            await _alunoRepository.Alterar(aluno);
        }

        public async Task<int> Inserir(AlunoEntity aluno)
        {
            return await _alunoRepository.Inserir(aluno);
        }

        public async Task Inativar(int id)
        {
            await _alunoRepository.Inativar(id);
        }
        public async Task<IEnumerable<AlunoEntity>> Listar()
        {
            return await _alunoRepository.Listar();
        }

        public async Task<AlunoEntity> ConsultarPorId(int id)
        {
            return await _alunoRepository.ConsultarPorId(id);
        }
    }
}
