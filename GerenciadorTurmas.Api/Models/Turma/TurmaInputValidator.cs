using FluentValidation;

namespace GerenciadorTurmas.Api.Models.Turma
{
    public class TurmaInputValidator : AbstractValidator<TurmaInput>
    {
        public TurmaInputValidator()
        {
            RuleFor(c => c.Turma).NotEmpty().WithMessage("Turma é obrigatório.")
                .MaximumLength(45).WithMessage("Turma deve conter no máximo 45 caracteres.")
                .MinimumLength(3).WithMessage("Turma deve conter no minimo 3 caracteres.");

            RuleFor(c => c.Ano).NotEmpty().WithMessage("Ano é obrigatório.")
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage($"Ano de ser igual ou superior a {DateTime.Now.Year}.");

        }
    }
}
