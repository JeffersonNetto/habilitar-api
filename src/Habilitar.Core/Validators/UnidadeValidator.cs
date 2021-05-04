using FluentValidation;
using Habilitar.Core.Models;

namespace Habilitar.Core.Validators
{
    public class UnidadeValidator : AbstractValidator<Unidade>
    {
        public UnidadeValidator()
        {
            RuleFor(_ => _.Nome)
                .NotEmpty()
                .WithMessage("Informe o nome");
        }
    }
}
