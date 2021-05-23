using Habilitar.Infra.Data;
using Habilitar.Core.Models;

namespace Habilitar.Infra.Repositories
{
    public class EmpresaRepository : RepositoryBase<Empresa>
    {        
        public EmpresaRepository(ApplicationDbContext context) : base(context) { }            
    }    
}
