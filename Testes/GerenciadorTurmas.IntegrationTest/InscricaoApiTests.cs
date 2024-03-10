using GerenciadorTurmas.Api.Models.Inscricao;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

namespace InscricaoApiTests.IntegrationTest
{
    public class InscricaoApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _webApplicationTest;

        public InscricaoApiTests(WebApplicationFactory<Program> webApplication)
        {
            _webApplicationTest = webApplication;
        }

        [Trait("Category", "Integration")]
        [Fact(DisplayName = "Testando chamada bem sucedida da rota 'inscricao/Listar'.")]
        public async Task ListarInscricao_ReturnsSuccessStatusCode()
        {
            var client = _webApplicationTest.CreateClient();

            var response = await client.GetAsync("/api/inscricao/listar");

            response.EnsureSuccessStatusCode();
        }

        [Trait("Category", "Integration")]
        [Theory(DisplayName = "Testando chamada bem sucedida da rota 'inscricao/ConsultarPorId/{id}'.")]
        [InlineData("Consultado Inscricao com Id 1", 1)]
        public async Task ConsultarInscricao_ReturnsSuccessStatusCode(string casoTeste, int inscricaoId)
        {
            var client = _webApplicationTest.CreateClient();

            var response = await client.GetAsync($"/api/inscricao/ConsultarPorId/{inscricaoId}");

            response.EnsureSuccessStatusCode();
        }

        [Trait("Category", "Integration")]
        [Theory(DisplayName = "Testando chamada bem sucedida da rota 'inscricao/Inativar/{id}'.")]
        [InlineData("Inativando Inscricao com Id 2", 2)]
        public async Task InativarInscricao_ReturnsSuccessStatusCode(string casoTeste, int inscricaoId)
        {
            var client = _webApplicationTest.CreateClient();

            var response = await client.DeleteAsync($"/api/inscricao/Inativar/{inscricaoId}");

            response.EnsureSuccessStatusCode();
        }

        [Trait("Category", "Integration")]
        [Fact(DisplayName = "Testando chamada bem sucedida da rota 'inscricao/Alterar'.")]
        public async Task AlterarInscricao_ReturnsSuccessStatusCode()
        {
            var client = _webApplicationTest.CreateClient();

            var inscricao = new InscricaoInput()
            {
                Id = 1,
                AlunoId = 1,
                TurmaId = 1,
            };

            string jsonContent = JsonSerializer.Serialize(inscricao);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("/api/inscricao/Alterar", content);

            response.EnsureSuccessStatusCode();
        }

        [Trait("Category", "Integration")]
        [Fact(DisplayName = "Testando chamada bem sucedida da rota 'inscricao/Inserir'.")]
        public async Task InserirInscricao_ReturnsSuccessStatusCode()
        {
            var client = _webApplicationTest.CreateClient();

            var inscricao = new InscricaoInput()
            {
                Id = null,
                AlunoId = 3,
                TurmaId = 3,
            };

            string jsonContent = JsonSerializer.Serialize(inscricao);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/inscricao/Inserir", content);

            response.EnsureSuccessStatusCode();
        }

        [Trait("Category", "Integration")]
        [Fact(DisplayName = "Testando chamada mal sucedida da rota 'inscricao/Alterar' com inscricao já cadastrada.")]
        public async Task AlterarInscricaoExistente_ReturnsSuccessStatusCode()
        {
            var client = _webApplicationTest.CreateClient();

            var inscricao = new InscricaoInput()
            {
                Id = 1,
                AlunoId = 2,
                TurmaId = 2,
            };

            string jsonContent = JsonSerializer.Serialize(inscricao);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("/api/inscricao/Alterar", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var mensagem = JObject.Parse(jsonResponse)["message"].ToString();

            Assert.Contains($"Esse aluno já esta cadastrado nesse turma.", mensagem);
        }

        [Trait("Category", "Integration")]
        [Fact(DisplayName = "Testando chamada mal sucedida da rota 'inscricao/Inserir' com inscricao já cadastrada.")]
        public async Task InserirInscricaoExistente_ReturnsSuccessStatusCode()
        {
            var client = _webApplicationTest.CreateClient();

            var inscricao = new InscricaoInput()
            {
                Id = null,
                AlunoId = 1,
                TurmaId = 1
            };

            string jsonContent = JsonSerializer.Serialize(inscricao);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/inscricao/Inserir", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var mensagem = JObject.Parse(jsonResponse)["message"].ToString();

            Assert.Contains($"Esse aluno já esta cadastrado nesse turma.", mensagem);

        }

        [Trait("Category", "Integration")]
        [Theory(DisplayName = "Testando chamada mal sucedida da rota 'inscricao/Inserir' com AlunoId invalido.")]
        [InlineData("AlunoId vazio", "Identificador de aluno é obrigatório.", 0)]
        [InlineData("AlunoId negativo", "Identificador de aluno é inválido.", -1)]
        public async Task InserirInscricaoAlunoIdInvalido_ReturnsBadStatusCode(string casoUso, string mensagemValidacaoEsperada, int alunoId)
        {
            var client = _webApplicationTest.CreateClient();

            var inscricao = new InscricaoInput()
            {
                Id = null,
                AlunoId = alunoId,
                TurmaId = 1
            };

            string jsonContent = JsonSerializer.Serialize(inscricao);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/inscricao/Inserir", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var arrayMensagem = JObject.Parse(jsonResponse)["errors"]["AlunoId"].Select(x => (string)x).ToArray();

            Assert.Contains(mensagemValidacaoEsperada, arrayMensagem);

        }

        [Trait("Category", "Integration")]
        [Theory(DisplayName = "Testando chamada mal sucedida da rota 'inscricao/Inserir' com AlunoId invalido.")]
        [InlineData("AlunoId vazio", "Identificador de turma é obrigatório.", 0)]
        [InlineData("AlunoId negativo", "Identificador de turma é inválido.", -1)]
        public async Task InserirInscricaoTurmaIdInvalido_ReturnsBadStatusCode(string casoUso, string mensagemValidacaoEsperada, int turmaId)
        {
            var client = _webApplicationTest.CreateClient();

            var inscricao = new InscricaoInput()
            {
                Id = null,
                AlunoId = 1,
                TurmaId = turmaId
            };

            string jsonContent = JsonSerializer.Serialize(inscricao);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/inscricao/Inserir", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var arrayMensagem = JObject.Parse(jsonResponse)["errors"]["TurmaId"].Select(x => (string)x).ToArray();

            Assert.Contains(mensagemValidacaoEsperada, arrayMensagem);

        }

    }
}
