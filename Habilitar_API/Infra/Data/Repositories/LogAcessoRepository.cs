using Habilitar_API.Data;
using Habilitar_API.Models;

namespace Habilitar_API.Repositories
{
    public class LogAcessoRepository : RepositoryBase<LogAcesso>
    {
        public LogAcessoRepository(HabilitarContext context) : base(context) { }
    }
}
