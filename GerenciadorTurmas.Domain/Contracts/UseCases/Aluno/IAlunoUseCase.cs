using GerenciadorTurmas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurmas.Domain.Contracts.UseCases.Aluno
{
    public interface IAlunoUseCase
    {
        Task<int> Inserir(AlunoEntity aluno);
    }
}
