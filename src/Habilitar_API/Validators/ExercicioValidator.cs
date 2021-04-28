using FluentValidation;
using Habilitar_API.Models;

namespace Habilitar_API.Validators
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
