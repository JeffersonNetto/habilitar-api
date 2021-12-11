using Habilitar.Infra.Data;
using Habilitar.Core.Models;
using Habilitar.Core.Repositories;

namespace Habilitar.Infra.Repositories
{
    public class MetricaRepository : RepositoryBase<Metrica>, IMetricaRepository
    {        
        public MetricaRepository(ApplicationDbContext context) : base(context) { }      
    }    
}
