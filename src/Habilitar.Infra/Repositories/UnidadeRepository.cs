using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar.Infra.Repositories
{
    public class UnidadeRepository : RepositoryBase<Unidade>, IUnidadeRepository
    {
        public UnidadeRepository(HabilitarContext context) : base(context) { }

        public async Task<IEnumerable<Unidade>> ObterComEmpresa() =>
            await _context.Unidade
                  .Include(u => u.Empresa)
                  .AsNoTracking()
                  .ToListAsync();
    }
}
