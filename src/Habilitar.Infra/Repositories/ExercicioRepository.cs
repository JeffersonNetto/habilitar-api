using Habilitar.Infra.Data;
using Habilitar.Core.Models;

namespace Habilitar.Infra.Repositories
{
    public class ExercicioRepository : RepositoryBase<Exercicio>
    {        
        public ExercicioRepository(HabilitarContext context) : base(context)
        {

        }            
    }
}
