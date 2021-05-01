using FluentValidation;
using Habilitar_API.Models;

namespace Habilitar_API.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(_ => _.Login)
                .NotEmpty()
                .WithMessage("Informe o login");
        }
    }
}
