using FluentValidation;
using Habilitar.Core.Models;

namespace Habilitar.Core.Validators
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
