using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario> Login(Usuario obj);
        Task<IEnumerable<Usuario>> ObterComPerfis();
        Task<Usuario> ObterComPerfis(int id);
    }
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(HabilitarContext context) : base(context) { }

        public async Task<Usuario> ObterComPerfis(int id)
        {
            return await _context.Usuario
                .Include(u => u.UsuarioPerfilUsuario)
                .ThenInclude(up => up.Perfil)
                .AsNoTracking()
                .SingleOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<IEnumerable<Usuario>> ObterComPerfis()
        {
            return await _context.Usuario
                .Include(u => u.UsuarioPerfilUsuario)
                .ThenInclude(up => up.Perfil)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Usuario> Login(Usuario obj) =>
            await _context.Usuario
            .AsNoTracking()
            .Include(_ => _.Pessoa)
            .FirstOrDefaultAsync(_ => _.Login == obj.Login && _.Senha == obj.Senha);
    }
}
