using FluentValidation;

namespace BancoDadosTest.Api.Models.Inscricao
{
    public class InscricaoInputValidator : AbstractValidator<InscricaoInput>
    {
        public InscricaoInputValidator()
        {
            RuleFor(c => c.AlunoId).NotEmpty().WithMessage("Identificador de aluno é obrigatório.")
                .GreaterThan(0).WithMessage($"Identificador de aluno é inválido.");
            RuleFor(c => c.TurmaId).NotEmpty().WithMessage("Identificador de turma é obrigatório.")
                .GreaterThan(0).WithMessage($"Identificador de turma é inválido.");
        }
    }
}
