using Habilitar_API.Data;
using Habilitar_API.Models;

namespace Habilitar_API.Repositories
{
    public class FuncaoRepository : RepositoryBase<Funcao>
    {
        public FuncaoRepository(HabilitarContext context) : base(context) { }
    }
}
