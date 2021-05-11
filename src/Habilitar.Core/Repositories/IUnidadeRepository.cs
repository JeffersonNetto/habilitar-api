using Habilitar.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar.Core.Repositories
{
    public interface IUnidadeRepository : IRepositoryBase<Unidade>
    {
        Task<IEnumerable<Unidade>> ObterComEmpresa();
    }
}
