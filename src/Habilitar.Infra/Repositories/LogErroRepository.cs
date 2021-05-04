using Habilitar.Infra.Data;
using Habilitar.Core.Models;

namespace Habilitar.Infra.Repositories
{
    public class LogErroRepository : RepositoryBase<LogErro>
    {
        public LogErroRepository(HabilitarContext context) : base(context) { }
    }
}
