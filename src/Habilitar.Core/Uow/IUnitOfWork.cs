using System;
using System.Threading.Tasks;

namespace Habilitar.Core.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
