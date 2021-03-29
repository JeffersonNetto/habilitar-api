using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public class MetaRepository : IRepositoryBase<Meta>
    {
        private readonly HabilitarContext _context;

        public MetaRepository(HabilitarContext context) =>
            _context = context;

        public async Task Add(Meta obj) =>
            await _context.Meta.AddAsync(obj);

        public async Task<bool> Exists<T>(T id) =>
            await _context.Meta
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id)) != null;

        public async Task<List<Meta>> GetAll() =>
            await _context.Meta
            .AsNoTracking()
            .ToListAsync();

        public async Task<Meta> GetById<T>(T id) =>
            await _context.Meta
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id));

        public void Remove(Meta obj) =>
            _context.Meta.Remove(obj);

        public void Update(Meta obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property("DataCriacao").IsModified = false;
            _context.Entry(obj).Property("UsuarioCriacaoId").IsModified = false;
        }
    }    
}
