using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Uow;
using Habilitar.Core.Validators;
using System;
using System.Threading.Tasks;

namespace Habilitar.Core.Services
{
    public interface IUnidadeService : IDisposable
    {
        Task<bool> Adicionar(Unidade obj);
        Task<bool> Atualizar(Unidade obj);
        Task<bool> Remover(int id);
    }

    public class UnidadeService : ServiceBase, IUnidadeService
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public UnidadeService(
            INotificador notificador,
            IUnitOfWork uow,
            IUnidadeRepository unidadeRepository) : base(notificador, uow) => _unidadeRepository = unidadeRepository;

        public async Task<bool> Adicionar(Unidade obj)
        {
            if (!await ExecutarValidacao(new UnidadeValidator(), obj))
                return false;

            await _unidadeRepository.Add(obj);
            await Commit();

            return true;
        }

        public async Task<bool> Atualizar(Unidade obj)
        {
            if (!await ExecutarValidacao(new UnidadeValidator(), obj))
                return false;

            _unidadeRepository.Update(obj);
            await Commit();

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            var empresa = await _unidadeRepository.GetById(id);

            if (empresa == null)
                Notificar($"Nenhuma unidade encontrada para o Id {id}");

            _unidadeRepository.Remove(empresa);
            await Commit();

            return true;
        }

        public void Dispose() => _unidadeRepository?.Dispose();
    }
}
