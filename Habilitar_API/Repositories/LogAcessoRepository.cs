using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public class LogAcessoRepository : IRepositoryBase<LogAcesso>
    {
        private readonly HabilitarContext _context;

        public LogAcessoRepository(HabilitarContext context) =>
            _context = context;

        public async Task Add(LogAcesso obj) =>
            await _context.LogAcesso.AddAsync(obj);

        public async Task<bool> Exists<T>(T id) =>
            await _context.LogAcesso
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id)) != null;

        public async Task<List<LogAcesso>> GetAll() =>
            await _context.LogAcesso
            .AsNoTracking()
            .ToListAsync();

        public async Task<LogAcesso> GetById<T>(T id) =>
            await _context.LogAcesso
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id));

        public void Remove(LogAcesso obj) =>
            _context.LogAcesso.Remove(obj);

        public void Update(LogAcesso obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property("DataCriacao").IsModified = false;
            _context.Entry(obj).Property("UsuarioCriacaoId").IsModified = false;
        }
    }
}
