using FluentValidation;

namespace GerenciadorTurmas.Api.Models.Aluno
{
    public class AlunoInputValidator : AbstractValidator<AlunoInput>
    {
        public AlunoInputValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(255).WithMessage("Nome deve conter no máximo 255 caracteres.")
                .MinimumLength(3).WithMessage("Nome deve conter no minimo 3 caracteres.");

            RuleFor(c => c.Usuario).NotEmpty().WithMessage("Usuário é obrigatório.")
                .MaximumLength(45).WithMessage("Usuário deve conter no máximo 45 caracteres.")
                .MinimumLength(3).WithMessage("Usuário deve conter no minimo 3 caracteres.");

            RuleFor(p => p.Senha).NotEmpty().WithMessage("Senha é obrigatório.")
                .MaximumLength(16).WithMessage("Senha deve conter no máximo 16 caracteres.")
                .MinimumLength(8).WithMessage("Senha deve conter no minimo 8 caracteres.")
                .Matches(@"[A-Z]+").WithMessage("Senha deve conter pelo menos uma letras maiúsculas.")
                .Matches(@"[a-z]+").WithMessage("Senha deve conter pelo menos uma letras minúsculas.")
                .Matches(@"[0-9]+").WithMessage("Senha deve conter pelo menos um numero.")
                .Matches(@"[\!\?\*\.]+").WithMessage("Senha deve conter pelo menos um (!? *.).");
        }
    }
}
