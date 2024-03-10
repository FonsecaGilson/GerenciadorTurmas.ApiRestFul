using GerenciadorTurmas.Api.Models.Aluno;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

namespace AlunoApiTests.IntegrationTest
{
    public class AlunoApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _webApplicationTest;

        public AlunoApiTests(WebApplicationFactory<Program> webApplication)
        {
            _webApplicationTest = webApplication;
        }

        [Trait("Category", "Integration")]
        [Fact(DisplayName = "Testando chamada bem sucedida da rota 'aluno/Listar'.")]
        public async Task ListarAluno_ReturnsSuccessStatusCode()
        {
            var client = _webApplicationTest.CreateClient();

            var response = await client.GetAsync("/api/aluno/listar");

            response.EnsureSuccessStatusCode();
        }

        [Trait("Category", "Integration")]
        [Theory(DisplayName = "Testando chamada bem sucedida da rota 'aluno/ConsultarPorId/{id}'.")]
        [InlineData("Consultado Aluno com Id 1", 1)]
        public async Task ConsultarAluno_ReturnsSuccessStatusCode(string casoTeste, int alunoId)
        {
            var client = _webApplicationTest.CreateClient();

            var response = await client.GetAsync($"/api/aluno/ConsultarPorId/{alunoId}");

            response.EnsureSuccessStatusCode();
        }

        [Trait("Category", "Integration")]
        [Theory(DisplayName = "Testando chamada bem sucedida da rota 'aluno/Inativar/{id}'.")]
        [InlineData("Inativando Aluno com Id 2", 2)]
        public async Task InativarAluno_ReturnsSuccessStatusCode(string casoTeste, int alunoId)
        {
            var client = _webApplicationTest.CreateClient();

            var response = await client.DeleteAsync($"/api/aluno/Inativar/{alunoId}");

            response.EnsureSuccessStatusCode();
        }

        [Trait("Category", "Integration")]
        [Fact(DisplayName = "Testando chamada bem sucedida da rota 'aluno/Alterar'.")]
        public async Task AlterarAluno_ReturnsSuccessStatusCode()
        {
            var client = _webApplicationTest.CreateClient();

            var aluno = new AlunoInput()
            {
                Id = 1,
                Nome = "Maria Helena",
                Usuario = "Marihel",
                Senha = "Mari123?"
            };

            string jsonContent = JsonSerializer.Serialize(aluno);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("/api/aluno/Alterar", content);

            response.EnsureSuccessStatusCode();
        }

        [Trait("Category", "Integration")]
        [Fact(DisplayName = "Testando chamada bem sucedida da rota 'aluno/Inserir'.")]
        public async Task InserirAluno_ReturnsSuccessStatusCode()
        {
            var client = _webApplicationTest.CreateClient();

            var aluno = new AlunoInput()
            {
                Id = null,
                Nome = "Maria Helena",
                Usuario = "Marihel",
                Senha = "Mari123?"
            };

            string jsonContent = JsonSerializer.Serialize(aluno);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/aluno/Inserir", content);

            response.EnsureSuccessStatusCode();
        }

        [Trait("Category", "Integration")]
        [Theory(DisplayName = "Testando chamada mal sucedida da rota 'aluno/Inserir' com senha fraca.")]
        [InlineData("Senha vazia", "Senha é obrigatório.", "")]
        [InlineData("Senha com mais de 16 caraceteres", "Senha deve conter no máximo 16 caracteres.", "Mariaaaaa123456789?")]
        [InlineData("Senha com menos de 8 caraceteres", "Senha deve conter no minimo 8 caracteres.", "Ma1?")]
        [InlineData("Senha sem numero", "Senha deve conter pelo menos um numero.", "Mariaaaa?")]
        [InlineData("Senha sem letras maiúsculas", "Senha deve conter pelo menos uma letras maiúsculas.", "maria1234")]
        [InlineData("Senha sem letras minúsculas", "Senha deve conter pelo menos uma letras minúsculas.", "MARIA1234")]
        [InlineData("Senha sem caraceteres (!? *.)", "Senha deve conter pelo menos um (!? *.).", "Maria1234")]
        public async Task InserirAlunoSenhaFraca_ReturnsBadStatusCode(string casoUso, string mensagemValidacaoEsperada, string senha)
        {
            var client = _webApplicationTest.CreateClient();

            var aluno = new AlunoInput()
            {
                Id = null,
                Nome = "Maria Helena",
                Usuario = "Marihel",
                Senha = senha
            };

            string jsonContent = JsonSerializer.Serialize(aluno);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/aluno/Inserir", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var arrayMensagem = JObject.Parse(jsonResponse)["errors"]["Senha"].Select(x => (string)x).ToArray();

            Assert.Contains(mensagemValidacaoEsperada, arrayMensagem);
        }

        [Trait("Category", "Integration")]
        [Theory(DisplayName = "Testando chamada mal sucedida da rota 'aluno/Inserir' com nome invalido.")]
        [InlineData("Nome vazio", "Nome é obrigatório.", "", 1)]
        [InlineData("Nome com mais de 255 caraceteres", "Nome deve conter no máximo 255 caracteres.", "Maria", 52)]
        [InlineData("Nome com menos de 3 caraceteres", "Nome deve conter no minimo 3 caracteres.", "Ma", 1)]
        public async Task InserirAlunoNomeInvalido_ReturnsBadStatusCode(string casoUso, string mensagemValidacaoEsperada, string nome, int repeticaoConcat)
        {
            var client = _webApplicationTest.CreateClient();

            nome = string.Concat(Enumerable.Repeat(nome, repeticaoConcat));

            var aluno = new AlunoInput()
            {
                Id = null,
                Nome = nome,
                Usuario = "Marihel",
                Senha = "Maria123?"
            };

            string jsonContent = JsonSerializer.Serialize(aluno);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/aluno/Inserir", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var arrayMensagem = JObject.Parse(jsonResponse)["errors"]["Nome"].Select(x => (string)x).ToArray();

            Assert.Contains(mensagemValidacaoEsperada, arrayMensagem);
        }

        [Trait("Category", "Integration")]
        [Theory(DisplayName = "Testando chamada mal sucedida da rota 'aluno/Inserir' com usuario invalido.")]
        [InlineData("Usuario vazio", "Usuário é obrigatório.", "", 1)]
        [InlineData("Usuario com mais de 45 caraceteres", "Usuário deve conter no máximo 45 caracteres.", "Marihel", 8)]
        [InlineData("Usuario com menos de 3 caraceteres", "Usuário deve conter no minimo 3 caracteres.", "Ma", 1)]
        public async Task InserirAlunoUsuarioInvalido_ReturnsBadStatusCode(string casoUso, string mensagemValidacaoEsperada, string usuario, int repeticaoConcat)
        {
            var client = _webApplicationTest.CreateClient();

            usuario = string.Concat(Enumerable.Repeat(usuario, repeticaoConcat));

            var aluno = new AlunoInput()
            {
                Id = null,
                Nome = "Maria Helena",
                Usuario = usuario,
                Senha = "Maria123?"
            };

            string jsonContent = JsonSerializer.Serialize(aluno);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/aluno/Inserir", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var arrayMensagem = JObject.Parse(jsonResponse)["errors"]["Usuario"].Select(x => (string)x).ToArray();

            Assert.Contains(mensagemValidacaoEsperada, arrayMensagem);
        }
    }
}
