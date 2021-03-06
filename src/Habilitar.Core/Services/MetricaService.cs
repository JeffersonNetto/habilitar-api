using Habilitar.Core.Models;
using Habilitar.Core.Uow;
using Habilitar.Core.Validators;
using System;
using System.Threading.Tasks;
using Habilitar.Core.Repositories;
using Habilitar.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Habilitar.Core.Services
{
    public interface IMetricaService : IDisposable
    {
        Task<bool> Adicionar(Metrica empresa);
        Task<bool> Atualizar(Metrica empresa);
        Task<bool> Remover(int id);
        Task<IEnumerable<ComboBase<int>>> ObterCombo();
    }

    public class MetricaService : ServiceBase, IMetricaService
    {
        private readonly IRepositoryBase<Metrica> _metricaRepository;

        public MetricaService(
            INotificador notificador,
            IUnitOfWork uow,
            IRepositoryBase<Metrica> metricaRepository) : base(notificador, uow) => _metricaRepository = metricaRepository;

        public async Task<bool> Adicionar(Metrica empresa)
        {
            if (!await ExecutarValidacao(new MetricaValidator(), empresa))
                return false;

            await _metricaRepository.Add(empresa);
            await Commit();

            return true;
        }

        public async Task<bool> Atualizar(Metrica empresa)
        {
            if (!await ExecutarValidacao(new MetricaValidator(), empresa))
                return false;

            _metricaRepository.Update(empresa);
            await Commit();

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            var empresa = await _metricaRepository.GetById(id);

            if (empresa == null)
                Notificar($"Nenhuma métrica encontrada para o Id {id}");

            _metricaRepository.Remove(empresa);
            await Commit();

            return true;
        }

        public void Dispose() => _metricaRepository?.Dispose();

        public async Task<IEnumerable<ComboBase<int>>> ObterCombo()
        {
            var lst = await _metricaRepository.GetAll();

            return lst.Select(obj => new ComboBase<int>
            {
                Value = obj.Id,
                Text = obj.Descricao,
            });
        }
    }
}
