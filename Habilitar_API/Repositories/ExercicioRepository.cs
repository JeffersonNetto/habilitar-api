using Habilitar_API.Data;
using Habilitar_API.Models;

namespace Habilitar_API.Repositories
{
    public class ExercicioRepository : RepositoryBase<Exercicio>
    {        
        public ExercicioRepository(HabilitarContext context) : base(context)
        {

        }            
    }
}
