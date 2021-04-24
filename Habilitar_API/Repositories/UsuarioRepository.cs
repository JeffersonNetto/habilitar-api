using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario> Login(Usuario obj);
    }

    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {        
        public UsuarioRepository(HabilitarContext context) : base(context)
        {

        }
       
        public async Task<Usuario> Login(Usuario obj) =>        
            await _context.Usuario
            .AsNoTracking()
            .Include(_ => _.Pessoa)
            .FirstOrDefaultAsync(_ => _.Login == obj.Login && _.Senha == obj.Senha);        
    }    
}
