using Habilitar_API.Data;
using Habilitar_API.Models;

namespace Habilitar_API.Repositories
{
    public class PerfilRepository : RepositoryBase<Perfil>
    {
        public PerfilRepository(HabilitarContext context) : base(context) { }
    }
}
