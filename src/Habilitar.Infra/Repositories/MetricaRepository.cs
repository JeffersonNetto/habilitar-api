using Habilitar.Infra.Data;
using Habilitar.Core.Models;

namespace Habilitar.Infra.Repositories
{
    public class MetricaRepository : RepositoryBase<Metrica>
    {        
        public MetricaRepository(HabilitarContext context) : base(context) { }      
    }    
}
