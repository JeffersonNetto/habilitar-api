using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Habilitar.Infra.Repositories
{
    public class ExercicioRepository : RepositoryBase<Exercicio>, IExercicioRepository
    {        
        public ExercicioRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Exercicio>> ObterComGrupos() =>        
            await _context.Exercicio
                  .Include(e => e.ExercicioGrupo)
                    .ThenInclude(eg => eg.Grupo)
                  .AsNoTracking()
                  .ToListAsync();

        public async Task<Exercicio> ObterComGrupos(int id) =>
            await _context.Exercicio
                  .Where(e => e.Id == id)
                  .Include(e => e.ExercicioGrupo)
                    .ThenInclude(eg => eg.Grupo)
                  .AsNoTracking()
                  .SingleOrDefaultAsync();

        public new void Update(Exercicio obj)
        {            
            
            _context.Entry(obj).Property(nameof(obj.DataCriacao)).IsModified = false;
            _context.Entry(obj).Property(nameof(obj.UsuarioCriacaoId)).IsModified = false;            

            var exercicioGrupos = _context.ExercicioGrupo.Where(eg => eg.ExercicioId == obj.Id).AsNoTracking().ToList();

            if(exercicioGrupos.Count > obj.ExercicioGrupo.Count)
            {
                foreach (var item in exercicioGrupos)
                {
                    if(!obj.ExercicioGrupo.Any(_ => _.GrupoId == item.GrupoId))
                    {
                        _context.Entry(item).State = EntityState.Deleted;
                    }
                }
            }
            else
            {
                foreach (var item in obj.ExercicioGrupo)
                {
                    if (!exercicioGrupos.Any(_ => _.GrupoId == item.GrupoId))
                    {
                        _context.Entry(item).State = EntityState.Added;
                    }
                }
            }

            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
