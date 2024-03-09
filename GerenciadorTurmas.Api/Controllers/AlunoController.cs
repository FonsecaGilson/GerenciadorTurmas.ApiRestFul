using GerenciadorTurmas.Api.Models.Aluno;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTurmas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Inserir(AlunoInput aluno)
        {
            return Ok();
        }
    }
}
