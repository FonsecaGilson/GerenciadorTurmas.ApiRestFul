using AutoMapper;
using GerenciadorTurmas.Api.Models.Turma;
using GerenciadorTurmas.Domain.Contracts.UseCases.Turma;
using GerenciadorTurmas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTurmas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITurmaUseCase _turmaUseCase;

        public TurmaController(IMapper mapper, ITurmaUseCase turmaUseCase)
        {
            _mapper = mapper;
            _turmaUseCase = turmaUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(TurmaInput turma)
        {
            return Ok(await _turmaUseCase.Inserir(_mapper.Map<TurmaEntity>(turma)));
        }

        [HttpPut]
        public async Task<IActionResult> Alterar(TurmaInput turma)
        {
            await _turmaUseCase.Alterar(_mapper.Map<TurmaEntity>(turma));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Inativar(int id)
        {
            await _turmaUseCase.Inativar(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _turmaUseCase.Listar());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            return Ok(await _turmaUseCase.ConsultarPorId(id));
        }
    }
}
