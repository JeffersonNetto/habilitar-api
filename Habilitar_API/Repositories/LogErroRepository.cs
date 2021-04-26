using Habilitar_API.Data;
using Habilitar_API.Models;

namespace Habilitar_API.Repositories
{
    public class LogErroRepository : RepositoryBase<LogErro>
    {
        public LogErroRepository(HabilitarContext context) : base(context) { }
    }
}
