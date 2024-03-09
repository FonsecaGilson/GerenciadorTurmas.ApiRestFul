using GerenciadorTurmas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurmas.Domain.Contracts.Repositories.Aluno
{
    public interface IAlunoRepository
    {
        Task<int> Inserir(AlunoEntity aluno);
    }
}
