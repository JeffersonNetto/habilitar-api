using FluentValidation;
using Habilitar_API.Models;

namespace Habilitar_API.Validators
{
    public class MetricaValidator : AbstractValidator<Metrica>
    {
        public MetricaValidator()
        {
            RuleFor(_ => _.Descricao)
                .NotEmpty()
                .WithMessage("Informe uma descrição");
        }
    }
}
