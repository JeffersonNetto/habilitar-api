using FluentValidation;
using Habilitar.Core.Models;

namespace Habilitar.Core.Validators
{
    public class ExercicioValidator : AbstractValidator<Exercicio>
    {
        public ExercicioValidator()
        {
            RuleFor(_ => _.Nome)
                .NotEmpty()
                .WithMessage("Informe o nome do exercício");
        }
    }
}
