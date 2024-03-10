using BancoDadosTest.Domain.Contracts.Repositories.Aluno;
using BancoDadosTest.Domain.Contracts.UseCases.Aluno;
using BancoDadosTest.Domain.Entities;

namespace BancoDadosTest.Application.UseCases
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
