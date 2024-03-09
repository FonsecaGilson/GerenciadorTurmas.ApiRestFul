using AutoMapper;
using FluentValidation;
using GerenciadorTurmas.Api.Models.Aluno;
using GerenciadorTurmas.Domain.Contracts.UseCases.Aluno;
using GerenciadorTurmas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTurmas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IAlunoUseCase _alunoUseCase;

        public AlunoController(IMapper mapper, IAlunoUseCase alunoUseCase)
        {
            _mapper = mapper;
            _alunoUseCase = alunoUseCase;         
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(AlunoInput aluno)
        {
            return Ok( await _alunoUseCase.Inserir(_mapper.Map<AlunoEntity>(aluno)));
        }
    }
}
