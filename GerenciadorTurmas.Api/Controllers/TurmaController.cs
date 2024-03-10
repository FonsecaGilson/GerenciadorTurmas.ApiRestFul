using AutoMapper;
using BancoDadosTest.Api.Common.Validator;
using BancoDadosTest.Api.Models.Turma;
using BancoDadosTest.Domain.Contracts.UseCases.Turma;
using BancoDadosTest.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BancoDadosTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITurmaUseCase _turmaUseCase;
        private readonly IdPayloadValidator _idPayloadValidator;

        public TurmaController(IMapper mapper, ITurmaUseCase turmaUseCase, IdPayloadValidator idPayloadValidator)
        {
            _mapper = mapper;
            _turmaUseCase = turmaUseCase;
            _idPayloadValidator = idPayloadValidator;
        }

        [HttpPost("Inserir")]
        public async Task<IActionResult> Inserir(TurmaInput turma)
        {
            return Ok(await _turmaUseCase.Inserir(_mapper.Map<TurmaEntity>(turma)));
        }

        [HttpPut("Alterar")]
        public async Task<IActionResult> Alterar(TurmaInput turma)
        {
            await _turmaUseCase.Alterar(_mapper.Map<TurmaEntity>(turma));
            return Ok();
        }

        [HttpDelete("Inativar/{id}")]
        public async Task<IActionResult> Inativar(int id)
        {
            var validationResult = _idPayloadValidator.Validate(id);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await _turmaUseCase.Inativar(id);

            return Ok();
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _turmaUseCase.Listar());
        }

        [HttpGet("ConsultarPorId/{id}")]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            var validationResult = _idPayloadValidator.Validate(id);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok(await _turmaUseCase.ConsultarPorId(id));
        }
    }
}
