using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public interface IPerfilRepository : IRepositoryBase<Perfil>
    {
        Task<IEnumerable<Perfil>> ObterComFuncoes();
    }

    public class PerfilRepository : RepositoryBase<Perfil>, IPerfilRepository
    {
        public PerfilRepository(HabilitarContext context) : base(context) { }

        public async Task<IEnumerable<Perfil>> ObterComFuncoes()
        {
            return await _context.Perfil
                .Include(p => p.PerfilFuncao)
                .ThenInclude(pf => pf.Funcao)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
