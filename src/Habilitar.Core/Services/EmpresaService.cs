using Habilitar.Core.Models;
using Habilitar.Core.Uow;
using Habilitar.Core.Validators;
using System;
using System.Threading.Tasks;
using Habilitar.Core.Repositories;

namespace Habilitar.Core.Services
{
    public interface IEmpresaService : IDisposable
    {
        Task<bool> Adicionar(Empresa empresa);
        Task<bool> Atualizar(Empresa empresa);
        Task<bool> Remover(int id);
    }

    public class EmpresaService : ServiceBase, IEmpresaService
    {
        private readonly IRepositoryBase<Empresa> _empresaRepository;

        public EmpresaService(
            INotificador notificador,
            IUnitOfWork uow,
            IRepositoryBase<Empresa> empresaRepository) : base(notificador, uow) => _empresaRepository = empresaRepository;

        public async Task<bool> Adicionar(Empresa empresa)
        {
            if (!await ExecutarValidacao(new EmpresaValidator(), empresa))
                return false;

            await _empresaRepository.Add(empresa);
            await Commit();

            return true;
        }

        public async Task<bool> Atualizar(Empresa empresa)
        {
            if (!await ExecutarValidacao(new EmpresaValidator(), empresa))
                return false;

            _empresaRepository.Update(empresa);
            await Commit();

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            var empresa = await _empresaRepository.GetById(id);

            if (empresa == null)
                Notificar($"Nenhuma empresa encontrada para o Id {id}");

            _empresaRepository.Remove(empresa);
            await Commit();

            return true;
        }

        public void Dispose() => _empresaRepository?.Dispose();
    }
}
