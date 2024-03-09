using FluentValidation;

namespace GerenciadorTurmas.Api.Models.Inscricao
{
    public class InscricaoInputValidator : AbstractValidator<InscricaoInput>
    {
        public InscricaoInputValidator()
        {
            RuleFor(c => c.AlunoId).NotEmpty().WithMessage("Identificador de aluno é obrigatório.");
            RuleFor(c => c.TurmaId).NotEmpty().WithMessage("Identificador de turma é obrigatório.");
        }
    }
}
