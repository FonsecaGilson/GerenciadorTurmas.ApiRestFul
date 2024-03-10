
using FluentValidation.TestHelper;
using GerenciadorTurmas.Api.Models.Aluno;
using GerenciadorTurmas.Api.Models.Inscricao;

namespace GerenciadorTurmas.UnitTest
{
    public class InscricaoInputValidatorTests
    {
        [Trait("Category", "Unit")]
        [Fact(DisplayName = "Testando InscricaoInputValidator com todos os atributos de InscricaoInput valorizados corretamente.")]
        public void InscricaoInputValidator_ShouldPassValidation()
        {
            var validator = new InscricaoInputValidator();
            var aluno = new InscricaoInput { AlunoId = 1, TurmaId = 1 };
            var resultoValidacao = validator.TestValidate(aluno);

            resultoValidacao.ShouldNotHaveValidationErrorFor(p => p.AlunoId);
            resultoValidacao.ShouldNotHaveValidationErrorFor(p => p.TurmaId);
        }

        [Trait("Category", "Unit")]
        [Theory(DisplayName = "Testando InscricaoInputValidator mensagem de retorno com o atributo AlunoId de InscricaoInput valorizado icorretamente.")]
        [InlineData("AlunoId zerado", 0)]
        [InlineData("AlunoId valor negativo", -1)]
        public void InscricaoInputValidator_NomeInvalido_ShouldReturnErrorMessage(string casoTeste, int alunoId )
        {
            var validator = new InscricaoInputValidator();
            var aluno = new InscricaoInput { AlunoId = alunoId, TurmaId = 1 };
            var resultoValidacao = validator.Validate(aluno);

            Assert.False(resultoValidacao.IsValid);
            Assert.Contains("Identificador de aluno", resultoValidacao.Errors[0].ErrorMessage);
        }

        [Trait("Category", "Unit")]
        [Theory(DisplayName = "Testando InscricaoInputValidator mensagem de retorno com o atributo TurmaId de InscricaoInput valorizado icorretamente.")]
        [InlineData("TurmaId zerado", 0)]
        [InlineData("TurmaId valor negativo", -1)]
        public void InscricaoInputValidator_TurmaInvalido_ShouldReturnErrorMessage(string casoTeste, int turmaId)
        {
            var validator = new InscricaoInputValidator();
            var aluno = new InscricaoInput { AlunoId = 1, TurmaId = turmaId };
            var resultoValidacao = validator.Validate(aluno);

            Assert.False(resultoValidacao.IsValid);
            Assert.Contains("Identificador de turma", resultoValidacao.Errors[0].ErrorMessage);
        }
    }
}
