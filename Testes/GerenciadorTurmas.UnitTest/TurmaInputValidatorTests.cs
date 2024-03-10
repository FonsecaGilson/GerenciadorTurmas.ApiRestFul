using FluentValidation.TestHelper;
using GerenciadorTurmas.Api.Models.Turma;

namespace GerenciadorTurmas.UnitTest
{
    public class TurmaInputValidatorTests
    {
        [Trait("Category", "Unit")]
        [Fact(DisplayName = "Testando TurmaInputValidator com todos os atributos de TurmaInput valorizados corretamente.")]
        public void TurmaInputValidator_ShouldPassValidation()
        {
            var validator = new TurmaInputValidator();
            var aluno = new TurmaInput { Turma = "Matematica", Ano = 2024 };
            var resultoValidacao = validator.TestValidate(aluno);

            resultoValidacao.ShouldNotHaveValidationErrorFor(p => p.Turma);
            resultoValidacao.ShouldNotHaveValidationErrorFor(p => p.Ano);
        }

        [Trait("Category", "Unit")]
        [Theory(DisplayName = "Testando TurmaInputValidator mensagem de retorno com o atributo Turma de TurmaInput valorizado icorretamente.")]
        [InlineData("Turma vazio", "", 1)]
        [InlineData("Turma com espaços em branco", "   ", 1)]
        [InlineData("Turma com menos de 3 caracteres", "Ma", 1)]
        [InlineData("Turma com mais de 45 caracteres", "Matematica", 5)]
        public void TurmaInputValidator_TrumaInvalida_ShouldReturnErrorMessage(string casoDeTeste, string turma, int repeticaoConcat)
        {
            turma = string.Concat(Enumerable.Repeat(turma, repeticaoConcat));

            var validator = new TurmaInputValidator();
            var aluno = new TurmaInput { Turma = turma, Ano = 2024 };

            var resultoValidacao = validator.Validate(aluno);

            Assert.False(resultoValidacao.IsValid);
            Assert.Contains("Turma", resultoValidacao.Errors[0].ErrorMessage);
        }

        [Trait("Category", "Unit")]
        [Theory(DisplayName = "Testando TurmaInputValidator mensagem de retorno com o atributo Ano de TurmaInput valorizado icorretamente.")]
        [InlineData("Ano zerado", 0)]
        [InlineData("Ano menor que o ano atual", 2023)]
        public void TurmaInputValidator_AnoInvalido_ShouldReturnErrorMessage(string casoDeTeste, int ano)
        {

            var validator = new TurmaInputValidator();
            var aluno = new TurmaInput { Turma = "Matematica", Ano = ano };

            var resultoValidacao = validator.Validate(aluno);

            Assert.False(resultoValidacao.IsValid);
            Assert.Contains("Ano", resultoValidacao.Errors[0].ErrorMessage);
        }
    }
}
