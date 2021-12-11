using Habilitar.Infra.Data;
using Habilitar.Core.Models;
using Habilitar.Core.Repositories;

namespace Habilitar.Infra.Repositories
{
    public class IntervaloRepository : RepositoryBase<Intervalo>, IIntervaloRepository
    {        
        public IntervaloRepository(ApplicationDbContext context) : base(context) { }
    }
}
