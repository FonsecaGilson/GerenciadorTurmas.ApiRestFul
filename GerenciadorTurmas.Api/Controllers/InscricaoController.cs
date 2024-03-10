using AutoMapper;
using BancoDadosTest.Api.Common.Validator;
using BancoDadosTest.Api.Models.Inscricao;
using BancoDadosTest.Domain.Contracts.UseCases.Inscriao;
using BancoDadosTest.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BancoDadosTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscricaoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IInscricaoUseCase _inscricaoUseCase;
        private readonly IdPayloadValidator _idPayloadValidator;

        public InscricaoController(IMapper mapper, IInscricaoUseCase inscricaoUseCase, IdPayloadValidator idPayloadValidator)
        {
            _mapper = mapper;
            _inscricaoUseCase = inscricaoUseCase;
            _idPayloadValidator = idPayloadValidator;
        }

        [HttpPost("Inserir")]
        public async Task<IActionResult> Inserir(InscricaoInput inscricao)
        {
            return Ok(await _inscricaoUseCase.Inserir(_mapper.Map<AlunoTurmaEntity>(inscricao)));
        }

        [HttpPut("Alterar")]
        public async Task<IActionResult> Alterar(InscricaoInput inscricao)
        {
            await _inscricaoUseCase.Alterar(_mapper.Map<AlunoTurmaEntity>(inscricao));
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

            await _inscricaoUseCase.Inativar(id);

            return Ok();
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _inscricaoUseCase.Listar());
        }

        [HttpGet("ConsultarPorId/{id}")]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            var validationResult = _idPayloadValidator.Validate(id);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok(await _inscricaoUseCase.ConsultarPorId(id));
        }
    }
}
