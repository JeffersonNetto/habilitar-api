using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar.Infra.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(HabilitarContext context) : base(context) { }

        public Task<Pessoa> GetByUserId(string userId) =>
            _context.Pessoa.SingleAsync(_ => _.UserId == userId);

        public async Task<IEnumerable<Pessoa>> ObterComUsuario()
        {
            return await _context.Pessoa
                        .Include(p => p.User)
                        .AsNoTracking()
                        .ToListAsync();
        }
    }
}
