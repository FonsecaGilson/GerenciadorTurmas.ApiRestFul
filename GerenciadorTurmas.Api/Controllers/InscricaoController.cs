using AutoMapper;
using GerenciadorTurmas.Api.Models.Inscricao;
using GerenciadorTurmas.Domain.Contracts.UseCases.Inscriao;
using GerenciadorTurmas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTurmas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InscricaoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IInscricaoUseCase _inscricaoUseCase;

        public InscricaoController(IMapper mapper, IInscricaoUseCase inscricaoUseCase)
        {
            _mapper = mapper;
            _inscricaoUseCase = inscricaoUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(InscricaoInput inscricao)
        {
            return Ok(await _inscricaoUseCase.Inserir(_mapper.Map<AlunoTurmaEntity>(inscricao)));
        }

        [HttpPut]
        public async Task<IActionResult> Alterar(InscricaoInput inscricao)
        {
            await _inscricaoUseCase.Alterar(_mapper.Map<AlunoTurmaEntity>(inscricao));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Inativar(int id)
        {
            await _inscricaoUseCase.Inativar(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _inscricaoUseCase.Listar());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            return Ok(await _inscricaoUseCase.ConsultarPorId(id));
        }
    }
}
