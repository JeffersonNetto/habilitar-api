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
    public interface IGrupoService : IDisposable
    {
        Task<bool> Adicionar(Grupo obj);
        Task<bool> Atualizar(Grupo obj);
        Task<bool> Remover(int id);
        Task<IEnumerable<ComboBase<int>>> ObterCombo();
    }

    public class GrupoService : ServiceBase, IGrupoService
    {
        private readonly IRepositoryBase<Grupo> _grupoRepository;

        public GrupoService(
            INotificador notificador,
            IUnitOfWork uow,
            IRepositoryBase<Grupo> grupoRepository) : base(notificador, uow) => _grupoRepository = grupoRepository;

        public async Task<bool> Adicionar(Grupo obj)
        {
            if (!await ExecutarValidacao(new GrupoValidator(), obj))
                return false;

            await _grupoRepository.Add(obj);
            await Commit();

            return true;
        }

        public async Task<bool> Atualizar(Grupo obj)
        {
            if (!await ExecutarValidacao(new GrupoValidator(), obj))
                return false;

            _grupoRepository.Update(obj);
            await Commit();

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            var empresa = await _grupoRepository.GetById(id);

            if (empresa == null)
                Notificar($"Nenhum grupo encontrado para o Id {id}");

            _grupoRepository.Remove(empresa);
            await Commit();

            return true;
        }

        public void Dispose() => _grupoRepository?.Dispose();

        public async Task<IEnumerable<ComboBase<int>>> ObterCombo()
        {
            var lst = await _grupoRepository.GetAll();

            return lst.Select(obj => new ComboBase<int>
            {
                Value = obj.Id,
                Text = obj.Descricao,
            });
        }
    }
}
