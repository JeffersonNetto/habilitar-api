using Habilitar.Core.Models;
using System;
using System.Threading.Tasks;

namespace Habilitar.Core.Repositories
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa>
    {
        Task<Pessoa> GetByUserId(Guid userId);
    }
}
