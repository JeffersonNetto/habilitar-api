using Habilitar.Infra.Data;
using Habilitar.Core.Models;
using Habilitar.Core.Repositories;

namespace Habilitar.Infra.Repositories
{
    public class GrupoRepository : RepositoryBase<Grupo>, IGrupoRepository
    {        
        public GrupoRepository(ApplicationDbContext context) : base(context) { }            
    }
}
