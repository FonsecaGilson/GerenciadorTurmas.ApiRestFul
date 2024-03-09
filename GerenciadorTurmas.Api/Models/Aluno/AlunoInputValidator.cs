using FluentValidation;

namespace GerenciadorTurmas.Api.Models.Aluno
{
    public class AlunoInputValidator: AbstractValidator<AlunoInput>
    {
        public AlunoInputValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().WithMessage("O nome do aluno é obrigatório.");
        }
    }
}
