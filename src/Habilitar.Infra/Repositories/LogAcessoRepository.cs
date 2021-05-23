using Habilitar.Infra.Data;
using Habilitar.Core.Models;

namespace Habilitar.Infra.Repositories
{
    public class LogAcessoRepository : RepositoryBase<LogAcesso>
    {
        public LogAcessoRepository(ApplicationDbContext context) : base(context) { }
    }
}
