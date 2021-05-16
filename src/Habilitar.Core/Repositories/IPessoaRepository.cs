using Habilitar.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar.Core.Repositories
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa>
    {
        Task<Pessoa> GetByUserId(string userId);
        Task<IEnumerable<Pessoa>> ObterComUsuario();
    }
}
