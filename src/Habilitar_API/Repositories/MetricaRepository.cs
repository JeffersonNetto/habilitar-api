using Habilitar_API.Data;
using Habilitar_API.Models;

namespace Habilitar_API.Repositories
{
    public class MetricaRepository : RepositoryBase<Metrica>
    {        
        public MetricaRepository(HabilitarContext context) : base(context) { }      
    }    
}
