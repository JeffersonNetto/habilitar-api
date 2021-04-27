using Habilitar_API.Data;
using System;
using System.Threading.Tasks;

namespace Habilitar_API.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
        Task Rollback();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly HabilitarContext _context;

        public UnitOfWork(HabilitarContext context) =>
            _context = context;

        public async Task<bool> Commit()
        {
            var success = (await _context.SaveChangesAsync()) > 0;

            // Possibility to dispatch domain events, etc

            return success;
        }

        public Task Rollback()
        {
            // Rollback anything, if necessary
            return Task.CompletedTask;
        }

        ~UnitOfWork() =>
            Dispose();

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
