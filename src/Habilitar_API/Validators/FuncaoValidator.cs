using FluentValidation;
using Habilitar_API.Models;

namespace Habilitar_API.Validators
{
    public class FuncaoValidator : AbstractValidator<Funcao>
    {
        public FuncaoValidator()
        {
            RuleFor(_ => _.Descricao)
                .NotEmpty()
                .WithMessage("Informe uma descrição");
        }
    }
}
