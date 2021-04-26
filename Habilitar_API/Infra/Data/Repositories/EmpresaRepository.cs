using Habilitar_API.Data;
using Habilitar_API.Models;

namespace Habilitar_API.Repositories
{
    public class EmpresaRepository : RepositoryBase<Empresa>
    {        
        public EmpresaRepository(HabilitarContext context) : base(context) { }            
    }    
}
