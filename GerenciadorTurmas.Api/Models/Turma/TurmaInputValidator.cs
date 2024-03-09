using FluentValidation;

namespace GerenciadorTurmas.Api.Models.Turma
{
    public class TurmaInputValidator : AbstractValidator<TurmaInput>
    {
        public TurmaInputValidator()
        {
            RuleFor(c => c.Turma).NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(45).WithMessage("Nome deve conter no máximo 45 caracteres.")
                .MinimumLength(3).WithMessage("Nome deve conter no minimo 3 caracteres.");

            RuleFor(c => c.Ano).NotEmpty().WithMessage("Ano é obrigatório.")
                .ExclusiveBetween(2000, 2100).WithMessage("Ano de ser entre 2000 e 2100.");

        }
    }
}
