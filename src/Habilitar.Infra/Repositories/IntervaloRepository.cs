using Habilitar.Infra.Data;
using Habilitar.Core.Models;

namespace Habilitar.Infra.Repositories
{
    public class IntervaloRepository : RepositoryBase<Intervalo>
    {        
        public IntervaloRepository(HabilitarContext context) : base(context) { }
    }
}
