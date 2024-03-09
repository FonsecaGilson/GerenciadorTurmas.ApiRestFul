using AutoMapper;
using GerenciadorTurmas.Api.Models.Inscricao;
using GerenciadorTurmas.Domain.Contracts.UseCases.Inscriao;
using GerenciadorTurmas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTurmas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscricaoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IInscricaoUseCase _inscricaoUseCase;

        public InscricaoController(IMapper mapper, IInscricaoUseCase inscricaoUseCase)
        {
            _mapper = mapper;
            _inscricaoUseCase = inscricaoUseCase;
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
            return Ok(await _inscricaoUseCase.ConsultarPorId(id));
        }
    }
}
