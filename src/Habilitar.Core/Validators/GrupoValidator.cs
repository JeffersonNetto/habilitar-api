using FluentValidation;
using Habilitar.Core.Models;

namespace Habilitar.Core.Validators
{
    public class GrupoValidator : AbstractValidator<Grupo>
    {
        public GrupoValidator()
        {
            RuleFor(_ => _.Descricao)
                .NotEmpty()
                .WithMessage("Informe uma descrição");
        }
    }
}
