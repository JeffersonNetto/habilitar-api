using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Uow;
using Habilitar.Core.Validators;
using System;
using System.Threading.Tasks;

namespace Habilitar.Core.Services
{
    public interface IIntervaloService : IDisposable
    {
        Task<bool> Adicionar(Intervalo obj);
        Task<bool> Atualizar(Intervalo obj);
        Task<bool> Remover(int id);
    }

    public class IntervaloService : ServiceBase, IIntervaloService
    {
        private readonly IRepositoryBase<Intervalo> _intervaloRepository;

        public IntervaloService(
            INotificador notificador,
            IUnitOfWork uow,
            IRepositoryBase<Intervalo> intervaloRepository) : base(notificador, uow) => _intervaloRepository = intervaloRepository;

        public async Task<bool> Adicionar(Intervalo obj)
        {
            if (!await ExecutarValidacao(new IntervaloValidator(), obj))
                return false;

            await _intervaloRepository.Add(obj);
            await Commit();

            return true;
        }

        public async Task<bool> Atualizar(Intervalo obj)
        {
            if (!await ExecutarValidacao(new IntervaloValidator(), obj))
                return false;

            _intervaloRepository.Update(obj);
            await Commit();

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            var empresa = await _intervaloRepository.GetById(id);

            if (empresa == null)
                Notificar($"Nenhum intervalo encontrado para o Id {id}");

            _intervaloRepository.Remove(empresa);
            await Commit();

            return true;
        }

        public void Dispose() => _intervaloRepository?.Dispose();
    }
}
