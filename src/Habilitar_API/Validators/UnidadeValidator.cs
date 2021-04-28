using FluentValidation;
using Habilitar_API.Models;

namespace Habilitar_API.Validators
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
