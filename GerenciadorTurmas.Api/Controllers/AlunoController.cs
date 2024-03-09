using AutoMapper;
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
            return Ok(await _alunoUseCase.Inserir(_mapper.Map<AlunoEntity>(aluno)));
        }

        [HttpPut]
        public async Task<IActionResult> Alterar(AlunoInput aluno)
        {
            await _alunoUseCase.Alterar(_mapper.Map<AlunoEntity>(aluno));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Inativar(int id)
        {
            await _alunoUseCase.Inativar(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _alunoUseCase.Listar());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            return Ok(await _alunoUseCase.ConsultarPorId(id));
        }
    }
}
