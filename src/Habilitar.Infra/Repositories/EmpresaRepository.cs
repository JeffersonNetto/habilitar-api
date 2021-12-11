using Habilitar.Infra.Data;
using Habilitar.Core.Models;
using Habilitar.Core.Repositories;

namespace Habilitar.Infra.Repositories
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {        
        public EmpresaRepository(ApplicationDbContext context) : base(context) { }            
    }    
}
