using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Infra.Data;

namespace Habilitar.Infra.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(HabilitarContext context) : base(context) { }
    }    
}
