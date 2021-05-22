using Habilitar.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar.Core.Repositories
{
    public interface IExercicioRepository : IRepositoryBase<Exercicio>
    {
        Task<IEnumerable<Exercicio>> ObterComGrupos();
        Task<Exercicio> ObterComGrupos(int id);
    }
}
