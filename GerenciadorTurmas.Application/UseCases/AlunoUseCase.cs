using GerenciadorTurmas.Domain.Contracts.Repositories.Aluno;
using GerenciadorTurmas.Domain.Contracts.UseCases.Aluno;
using GerenciadorTurmas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurmas.Application.UseCases
{
    public class AlunoUseCase : IAlunoUseCase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<int> Inserir(AlunoEntity aluno)
        {
            return await _alunoRepository.Inserir(aluno);
        }
    }
}
