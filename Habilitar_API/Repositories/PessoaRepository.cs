using Habilitar_API.Data;
using Habilitar_API.Models;

namespace Habilitar_API.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>
    {
        public PessoaRepository(HabilitarContext context) : base(context) { }
    }    
}
