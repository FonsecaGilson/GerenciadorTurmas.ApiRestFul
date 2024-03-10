using GerenciadorTurmas.Api.Models.Aluno;
using FluentValidation.TestHelper;

namespace GerenciadorTurmas.UnitTest
{
    public class AlunoInputValidatorTests
    {
        [Trait("Category", "Unit")]
        [Fact(DisplayName = "Testando AlunoInputValidator com todos os atributos de AlunoInput valorizados corretamente.")]
        public void AlunoInputValidator_ShouldPassValidation()
        {
            var validator = new AlunoInputValidator();
            var aluno = new AlunoInput { Nome = "Maria Helena", Usuario = "Marihel", Senha = "Marihel123?" };
            var resultoValidacao = validator.TestValidate(aluno);

            resultoValidacao.ShouldNotHaveValidationErrorFor(p => p.Nome);
            resultoValidacao.ShouldNotHaveValidationErrorFor(p => p.Usuario);
            resultoValidacao.ShouldNotHaveValidationErrorFor(p => p.Senha);
        }

        [Trait("Category", "Unit")]
        [Theory(DisplayName = "Testando AlunoInputValidator mensagem de retorno com o atributo Nome de AlunoInput valorizado icorretamente.")]
        [InlineData("Nome vazio", "", 1)]
        [InlineData("Nome com espaços em branco", "   ", 1)]
        [InlineData("Nome com menos de 3 caracteres", "Ma", 1)]
        [InlineData("Nome com mais de 255 caracteres", "Lorem ipsum dolor sit amet, consectetur adipiscing", 6)]
        public void AlunoInputValidator_NomeInvalido_ShouldReturnErrorMessage(string casoDeTeste, string nome, int repeticaoConcat)
        {
            nome = string.Concat(Enumerable.Repeat(nome, repeticaoConcat));

            var validator = new AlunoInputValidator();
            var aluno = new AlunoInput { Nome = nome, Usuario = "Marihel", Senha = "Marihel123?" };
            var resultoValidacao = validator.Validate(aluno);

            Assert.False(resultoValidacao.IsValid);
            Assert.Contains("Nome", resultoValidacao.Errors[0].ErrorMessage);
        }

        [Trait("Category", "Unit")]
        [Theory(DisplayName = "Testando AlunoInputValidator mensagem de retorno com o atributo Usuário de AlunoInput valorizado icorretamente.")]
        [InlineData("Usuario vazio", "", 1)]
        [InlineData("Usuario com espaços em branco", "   ", 1)]
        [InlineData("Usuario com menos de 3 caracteres", "Ma", 1)]
        [InlineData("Usuario com mais de 45 caracteres", "Maria", 10)]
        public void AlunoInputValidator_UsuarioInvalido_ShouldReturnErrorMessage(string casoDeTeste, string usuario, int repeticaoConcat)
        {
            usuario = string.Concat(Enumerable.Repeat(usuario, repeticaoConcat));

            var validator = new AlunoInputValidator();
            var aluno = new AlunoInput { Nome = "Maria Helena", Usuario = usuario, Senha = "Marihel123?" };
            var resultoValidacao = validator.Validate(aluno);

            Assert.False(resultoValidacao.IsValid);
            Assert.Contains("Usuário", resultoValidacao.Errors[0].ErrorMessage);
        }

        [Trait("Category", "Unit")]
        [Theory(DisplayName = "Testando AlunoInputValidator mensagem de retorno com o atributo Senha de AlunoInput valorizado icorretamente.")]
        [InlineData("Senha vazia", "", 1)]
        [InlineData("Senha com espaços em branco", "   ", 1)]
        [InlineData("Senha com menos de 8 caracteres", "Maria12", 1)]
        [InlineData("Senha com mais de 16 caracteres", "Maria", 4)]
        [InlineData("Senha sem nehum dos caracteres especiais (!? *.)", "Maria123", 1)]
        [InlineData("Senha sem uma letras maiúsculas", "maria123?", 1)]
        [InlineData("Senha sem uma letras minúsculas", "MARIA123?", 1)]
        [InlineData("Senha sem um numero", "Mariaaaa?", 1)]
        public void AlunoInputValidator_SenhaInvalida_ShouldReturnErrorMessage(string casoDeTeste, string senha, int repeticaoConcat)
        {
            senha = string.Concat(Enumerable.Repeat(senha, repeticaoConcat));

            var validator = new AlunoInputValidator();
            var aluno = new AlunoInput { Nome = "Maria Helena", Usuario = "Marihel", Senha = senha };
            var resultoValidacao = validator.Validate(aluno);

            Assert.False(resultoValidacao.IsValid);
            Assert.Contains("Senha", resultoValidacao.Errors[0].ErrorMessage);
        }
    }
}
