using Habilitar.Infra.Data;
using Habilitar.Core.Models;

namespace Habilitar.Infra.Repositories
{
    public class MetaRepository : RepositoryBase<Meta>
    {
        public MetaRepository(ApplicationDbContext context) : base(context) { }
    }
}
