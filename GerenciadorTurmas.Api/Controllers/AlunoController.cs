using AutoMapper;
using GerenciadorTurmas.Api.Common.Validator;
using GerenciadorTurmas.Api.Models.Aluno;
using GerenciadorTurmas.Domain.Contracts.UseCases.Aluno;
using GerenciadorTurmas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTurmas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IAlunoUseCase _alunoUseCase;
        private readonly IdPayloadValidator _idPayloadValidator;

        public AlunoController(IMapper mapper, IAlunoUseCase alunoUseCase, IdPayloadValidator idPayloadValidator)
        {
            _mapper = mapper;
            _alunoUseCase = alunoUseCase;
            _idPayloadValidator = idPayloadValidator;  
        }

        [HttpPost("Inserir")]
        public async Task<IActionResult> Inserir(AlunoInput aluno)
        {
            return Ok(await _alunoUseCase.Inserir(_mapper.Map<AlunoEntity>(aluno)));
        }

        [HttpPut("Alterar")]
        public async Task<IActionResult> Alterar(AlunoInput aluno)
        {
            await _alunoUseCase.Alterar(_mapper.Map<AlunoEntity>(aluno));
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

            await _alunoUseCase.Inativar(id);
            return Ok();
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _alunoUseCase.Listar());
        }

        [HttpGet("ConsultarPorId/{id}")]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            var validationResult = _idPayloadValidator.Validate(id);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok(await _alunoUseCase.ConsultarPorId(id));
        }
    }
}
