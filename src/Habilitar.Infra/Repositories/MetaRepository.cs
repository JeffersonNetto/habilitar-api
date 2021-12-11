using Habilitar.Infra.Data;
using Habilitar.Core.Models;
using Habilitar.Core.Repositories;

namespace Habilitar.Infra.Repositories
{
    public class MetaRepository : RepositoryBase<Meta>, IMetaRepository
    {
        public MetaRepository(ApplicationDbContext context) : base(context) { }
    }
}
