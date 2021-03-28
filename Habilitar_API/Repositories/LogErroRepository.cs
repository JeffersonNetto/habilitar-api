using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public class LogErroRepository : IRepositoryBase<LogErro>
    {
        private readonly HabilitarContext _context;

        public LogErroRepository(HabilitarContext context) =>
            _context = context;

        public async Task Add(LogErro obj) =>
            await _context.LogErro.AddAsync(obj);

        public async Task<bool> Exists<T>(T id) =>
            await _context.LogErro
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id)) != null;

        public async Task<List<LogErro>> GetAll() =>
            await _context.LogErro
            .AsNoTracking()
            .ToListAsync();

        public async Task<LogErro> GetById<T>(T id) =>
            await _context.LogErro
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id));

        public void Remove(LogErro obj) =>
            _context.LogErro.Remove(obj);

        public void Update(LogErro obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property("DataCriacao").IsModified = false;
            _context.Entry(obj).Property("UsuarioCriacaoId").IsModified = false;
        }
    }
}
