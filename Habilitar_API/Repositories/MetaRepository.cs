using Habilitar_API.Data;
using Habilitar_API.Models;

namespace Habilitar_API.Repositories
{
    public class MetaRepository : RepositoryBase<Meta>
    {
        public MetaRepository(HabilitarContext context) : base(context) { }
    }
}
