using FluentValidation;
using Habilitar_API.Models;

namespace Habilitar_API.Validators
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
