using Habilitar_API.Data;
using Habilitar_API.Models;

namespace Habilitar_API.Repositories
{
    public class UnidadeRepository : RepositoryBase<Unidade>
    {
        public UnidadeRepository(HabilitarContext context) : base(context) { }
    }
}
