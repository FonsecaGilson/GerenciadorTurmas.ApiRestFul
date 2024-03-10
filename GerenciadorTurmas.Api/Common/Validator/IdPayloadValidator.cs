using FluentValidation;

namespace BancoDadosTest.Api.Common.Validator
{
    public class IdPayloadValidator : AbstractValidator<int>
    {
        public IdPayloadValidator()
        {
            RuleFor(x => x).NotEmpty().WithMessage("O identificador não pode estar vazio.");
        }
    }
}
