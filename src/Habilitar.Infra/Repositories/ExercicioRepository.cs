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
        public ExercicioRepository(HabilitarContext context) : base(context) { }

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
            var lst = _context.ExercicioGrupo.Where(eg => eg.ExercicioId == obj.Id).AsNoTracking().ToList();

            _context.Entry(obj).State = EntityState.Modified;            

            foreach (var item in obj.ExercicioGrupo)
            {
                item.Ip = obj.Ip;
                                
                if (item.ExercicioId == 0)
                {
                    item.ExercicioId = obj.Id;                    
                    _context.Entry(item).State = EntityState.Added;                                        
                }
                else
                {
                    item.DataAtualizacao = obj.DataAtualizacao;
                    _context.Entry(item).State = EntityState.Modified;
                }                    
            }

            var result = lst.Except(obj.ExercicioGrupo);

            foreach (var item in result)            
                _context.Entry(item).State = EntityState.Deleted;            
            
            _context.Entry(obj).Property("DataCriacao").IsModified = false;
            _context.Entry(obj).Property("UsuarioCriacaoId").IsModified = false;
        }
    }
}
