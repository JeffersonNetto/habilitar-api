using Habilitar.Infra.Data;
using Habilitar.Core.Models;

namespace Habilitar.Infra.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>
    {
        public PessoaRepository(HabilitarContext context) : base(context) { }
    }    
}
