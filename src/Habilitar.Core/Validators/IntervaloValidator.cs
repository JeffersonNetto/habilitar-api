using FluentValidation;
using Habilitar.Core.Models;

namespace Habilitar.Core.Validators
{
    public class IntervaloValidator : AbstractValidator<Intervalo>
    {
        public IntervaloValidator()
        {
            RuleFor(_ => _.Descricao)
                .NotEmpty()
                .WithMessage("Informe uma descrição");
        }
    }
}
