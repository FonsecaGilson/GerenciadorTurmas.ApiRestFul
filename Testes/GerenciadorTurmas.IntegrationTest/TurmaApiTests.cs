using BancoDadosTest.Api.Models.Turma;
using BancoDadosTest.IntegrationTest;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

namespace TurmaApiTests.IntegrationTest
{
    public class TurmaApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _webApplicationTest;
        private readonly BancoDadosTeste _bancoDadosTeste;

        public TurmaApiTests(WebApplicationFactory<Program> webApplication)
        {
            _webApplicationTest = webApplication;
            //_bancoDadosTeste.ExecutarScript("..\\Scripts SQL\\Create");
        }

        [Trait("Category", "Integration")]
        [Fact(DisplayName = "Testando chamada bem sucedida da rota 'turma/Listar'.")]
        public async Task ListarTurma_ReturnsSuccessStatusCode()
        {
            var client = _webApplicationTest.CreateClient();

            var response = await client.GetAsync("/api/turma/listar");

            response.EnsureSuccessStatusCode();
        }

        [Trait("Category", "Integration")]
        [Theory(DisplayName = "Testando chamada bem sucedida da rota 'turma/ConsultarPorId/{id}'.")]
        [InlineData("Consultado Turma com Id 1", 1)]
        public async Task ConsultarTurma_ReturnsSuccessStatusCode(string casoTeste, int turmaId)
        {
            var client = _webApplicationTest.CreateClient();

            var response = await client.GetAsync($"/api/turma/ConsultarPorId/{turmaId}");

            response.EnsureSuccessStatusCode();
        }

        [Trait("Category", "Integration")]
        [Theory(DisplayName = "Testando chamada bem sucedida da rota 'turma/Inativar/{id}'.")]
        [InlineData("Inativando Turma com Id 1", 1)]
        public async Task InativarTurma_ReturnsSuccessStatusCode(string casoTeste, int turmaId)
        {
            var client = _webApplicationTest.CreateClient();

            var response = await client.DeleteAsync($"/api/turma/Inativar/{turmaId}");

            response.EnsureSuccessStatusCode();
        }

        [Trait("Category", "Integration")]
        [Fact(DisplayName = "Testando chamada bem sucedida da rota 'turma/Alterar'.")]
        public async Task AlterarTurma_ReturnsSuccessStatusCode()
        {
            var client = _webApplicationTest.CreateClient();

            var turma = new TurmaInput()
            {
                Id = 1,
                Turma = "Portugues",
                Ano = 2024,
            };

            string jsonContent = JsonSerializer.Serialize(turma);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("/api/turma/Alterar", content);

            response.EnsureSuccessStatusCode();
        }

        [Trait("Category", "Integration")]
        [Fact(DisplayName = "Testando chamada bem sucedida da rota 'turma/Inserir'.")]
        public async Task InserirTurma_ReturnsSuccessStatusCode()
        {
            var client = _webApplicationTest.CreateClient();

            var turma = new TurmaInput()
            {
                Id = null,
                Turma = "História",
                Ano = 2025,
            };

            string jsonContent = JsonSerializer.Serialize(turma);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/turma/Inserir", content);

            response.EnsureSuccessStatusCode();
        }

        [Trait("Category", "Integration")]
        [Fact(DisplayName = "Testando chamada mal sucedida da rota 'turma/Alterar' com turma já cadastrada.")]
        public async Task AlterarTurmaExistente_ReturnsSuccessStatusCode()
        {
            var client = _webApplicationTest.CreateClient();

            var turma = new TurmaInput()
            {
                Id = 1,
                Turma = "Matemática",
                Ano = 2024,
            };

            string jsonContent = JsonSerializer.Serialize(turma);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("/api/turma/Alterar", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var mensagem = JObject.Parse(jsonResponse)["message"].ToString();

            Assert.Contains($"Já existe uma turma cadastrada com o nome {turma.Turma}.", mensagem);
        }

        [Trait("Category", "Integration")]
        [Fact(DisplayName = "Testando chamada mal sucedida da rota 'turma/Inserir' com turma já cadastrada.")]
        public async Task InserirTurmaExistente_ReturnsSuccessStatusCode()
        {
            var client = _webApplicationTest.CreateClient();

            var turma = new TurmaInput()
            {
                Id = null,
                Turma = "Matemática",
                Ano = 2024,
            };

            string jsonContent = JsonSerializer.Serialize(turma);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/turma/Inserir", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var mensagem = JObject.Parse(jsonResponse)["message"].ToString();

            Assert.Contains($"Já existe uma turma cadastrada com o nome {turma.Turma}.", mensagem);

        }

        [Trait("Category", "Integration")]
        [Theory(DisplayName = "Testando chamada mal sucedida da rota 'turma/Inserir' com nome invalido.")]
        [InlineData("Turma vazio", "Turma é obrigatório.", "", 1)]
        [InlineData("Turma com mais de 45 caraceteres", "Turma deve conter no máximo 45 caracteres.", "Fisica", 8)]
        [InlineData("Turma com menos de 3 caraceteres", "Turma deve conter no minimo 3 caracteres.", "Fi", 1)]
        public async Task InserirAlunoTurmaInvalido_ReturnsBadStatusCode(string casoUso, string mensagemValidacaoEsperada, string nome, int repeticaoConcat)
        {
            var client = _webApplicationTest.CreateClient();

            nome = string.Concat(Enumerable.Repeat(nome, repeticaoConcat));

            var turma = new TurmaInput()
            {
                Id = null,
                Turma = nome,
                Ano = 2024
            };

            string jsonContent = JsonSerializer.Serialize(turma);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/turma/Inserir", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var arrayMensagem = JObject.Parse(jsonResponse)["errors"]["Turma"].Select(x => (string)x).ToArray();

            Assert.Contains(mensagemValidacaoEsperada, arrayMensagem);
        }

        [Trait("Category", "Integration")]
        [Theory(DisplayName = "Testando chamada mal sucedida da rota 'turma/Inserir' com ano invalido.")]
        [InlineData("Ano vazio", "Ano é obrigatório.", null)]
        [InlineData("Ano inferior ao atual", $"Ano de ser igual ou superior a ano atual.", 1990)]
        public async Task InserirAlunoAnoInvalido_ReturnsBadStatusCode(string casoUso, string mensagemValidacaoEsperada, int ano)
        {
            var client = _webApplicationTest.CreateClient();

            var turma = new TurmaInput()
            {
                Id = null,
                Turma = "Calculo II",
                Ano = ano
            };

            string jsonContent = JsonSerializer.Serialize(turma);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/turma/Inserir", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var arrayMensagem = JObject.Parse(jsonResponse)["errors"]["Ano"].Select(x => (string)x).ToArray();

            Assert.Contains(mensagemValidacaoEsperada, arrayMensagem);
        }
    }
}
