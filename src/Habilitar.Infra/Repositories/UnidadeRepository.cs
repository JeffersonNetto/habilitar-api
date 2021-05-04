using Habilitar.Infra.Data;
using Habilitar.Core.Models;

namespace Habilitar.Infra.Repositories
{
    public class UnidadeRepository : RepositoryBase<Unidade>
    {
        public UnidadeRepository(HabilitarContext context) : base(context) { }
    }
}
