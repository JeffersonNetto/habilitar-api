using Habilitar_API.Data;
using Habilitar_API.Models;

namespace Habilitar_API.Repositories
{
    public class GrupoRepository : RepositoryBase<Grupo>
    {        
        public GrupoRepository(HabilitarContext context) : base(context) { }            
    }
}
