using Habilitar_API.Data;
using Habilitar_API.Models;

namespace Habilitar_API.Repositories
{
    public class IntervaloRepository : RepositoryBase<Intervalo>
    {        
        public IntervaloRepository(HabilitarContext context) : base(context) { }
    }
}
