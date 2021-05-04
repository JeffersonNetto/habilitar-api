using FluentValidation;
using Habilitar.Core.Models;

namespace Habilitar.Core.Validators
{
    public class EmpresaValidator : AbstractValidator<Empresa>
    {
        public EmpresaValidator()
        {
            RuleFor(_ => _.NomeFantasia)
                .NotEmpty()
                .WithMessage("Informe o {PropertyName}");

            RuleFor(_ => _.RazaoSocial)
                .NotEmpty()
                .WithMessage("Informe a Razão Social");
        }
    }
}
