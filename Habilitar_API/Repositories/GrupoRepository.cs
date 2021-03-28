using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public class GrupoRepository : IRepositoryBase<Grupo>
    {
        private readonly HabilitarContext _context;

        public GrupoRepository(HabilitarContext context) =>
            _context = context;

        public async Task Add(Grupo obj) =>
            await _context.Grupo.AddAsync(obj);

        public async Task<bool> Exists<T>(T id) =>
            await _context.Grupo
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id)) != null;

        public async Task<List<Grupo>> GetAll() =>
            await _context.Grupo
            .AsNoTracking()
            .ToListAsync();

        public async Task<Grupo> GetById<T>(T id) =>
            await _context.Grupo            
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id));

        public void Remove(Grupo obj) =>
            _context.Grupo.Remove(obj);

        public void Update(Grupo obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property("DataCriacao").IsModified = false;
            _context.Entry(obj).Property("UsuarioCriacaoId").IsModified = false;
        }
    }
}
