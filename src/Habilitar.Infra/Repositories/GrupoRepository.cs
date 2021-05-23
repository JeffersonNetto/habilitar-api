using Habilitar.Infra.Data;
using Habilitar.Core.Models;

namespace Habilitar.Infra.Repositories
{
    public class GrupoRepository : RepositoryBase<Grupo>
    {        
        public GrupoRepository(ApplicationDbContext context) : base(context) { }            
    }
}
