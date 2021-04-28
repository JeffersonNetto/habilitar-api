using FluentValidation;
using Habilitar_API.Models;

namespace Habilitar_API.Validators
{
    public class PerfilValidator : AbstractValidator<Perfil>
    {
        public PerfilValidator()
        {
            RuleFor(_ => _.Descricao)
                .NotEmpty()
                .WithMessage("Informe uma descrição");
        }
    }
}
