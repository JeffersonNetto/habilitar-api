using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario> Login(string login, string senha);
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
                .Include(_ => _.Pessoa)
                .Include(_ => _.Unidade)
                .AsNoTracking()
                .SingleOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<IEnumerable<Usuario>> ObterComPerfis()
        {
            return await _context.Usuario
                .Include(u => u.UsuarioPerfilUsuario)
                    .ThenInclude(up => up.Perfil)
                .Include(_ => _.Pessoa)
                .Include(_ => _.Unidade)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Usuario> Login(string login, string senha) =>
            await _context.Usuario
            .Include(u => u.UsuarioPerfilUsuario)
                .ThenInclude(up => up.Perfil)
            .Include(_ => _.Pessoa)
            .Include(_ => _.Unidade)
            .AsNoTracking()
            .SingleOrDefaultAsync(_ => _.Login == login && _.Senha == senha);
    }
}
