using FluentValidation;
using FluentValidation.Results;
using Habilitar.Core.Helpers;
using Habilitar.Core.Uow;
using System.Threading.Tasks;

namespace Habilitar.Core.Services
{
    public abstract class ServiceBase
    {
        private readonly INotificador _notificador;
        private readonly IUnitOfWork _uow;

        protected ServiceBase(INotificador notificador, IUnitOfWork uow)
        {
            _notificador = notificador;
            _uow = uow;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                Notificar(error.ErrorMessage);
        }

        protected void Notificar(string mensagem) => _notificador.Handle(new Notificacao(mensagem));

        protected async Task<bool> ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : class
        {
            var result = await validacao.ValidateAsync(entidade);

            if (!result.IsValid)
            {
                Notificar(result);
                return false;
            }

            return true;
        }

        protected async Task Commit() => await _uow.Commit();
    }
}
