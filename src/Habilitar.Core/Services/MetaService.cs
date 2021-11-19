using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Uow;
using Habilitar.Core.Validators;
using Habilitar.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Habilitar.Core.Services
{
    public interface IMetaService : IDisposable
    {
        Task<bool> Adicionar(Meta Meta);
        Task<bool> Atualizar(Meta Meta);
        Task<bool> Remover(int id);        
    }

    public class MetaService : ServiceBase, IMetaService
    {
        private readonly IRepositoryBase<Meta> _MetaRepository;

        public MetaService(
            INotificador notificador,
            IUnitOfWork uow,
            IRepositoryBase<Meta> MetaRepository) : base(notificador, uow) => _MetaRepository = MetaRepository;

        public async Task<bool> Adicionar(Meta Meta)
        {
            if (!await ExecutarValidacao(new MetaValidator(), Meta))
                return false;

            await _MetaRepository.Add(Meta);
            await Commit();

            return true;
        }

        public async Task<bool> Atualizar(Meta Meta)
        {
            if (!await ExecutarValidacao(new MetaValidator(), Meta))
                return false;

            _MetaRepository.Update(Meta);
            await Commit();

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            var Meta = await _MetaRepository.GetById(id);

            if (Meta == null)
                Notificar($"Nenhuma Meta encontrada para o Id {id}");

            _MetaRepository.Remove(Meta);
            await Commit();

            return true;
        }

        public void Dispose() => _MetaRepository?.Dispose();
    }
}
