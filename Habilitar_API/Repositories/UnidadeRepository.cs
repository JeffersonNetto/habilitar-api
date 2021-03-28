using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public class UnidadeRepository : IRepositoryBase<Unidade>
    {
        private readonly HabilitarContext _context;

        public UnidadeRepository(HabilitarContext context) =>
            _context = context;

        public async Task Add(Unidade obj) =>
            await _context.Unidade.AddAsync(obj);

        public async Task<bool> Exists<T>(T id) =>
            await _context.Unidade            
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id)) != null;

        public async Task<List<Unidade>> GetAll() =>
            await _context.Unidade            
            .AsNoTracking()
            .ToListAsync();

        public async Task<Unidade> GetById<T>(T id) =>
            await _context.Unidade
            .Include(_ => _.Empresa)
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id));

        public void Remove(Unidade obj) =>
            _context.Unidade.Remove(obj);

        public void Update(Unidade obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property("DataCriacao").IsModified = false;
            _context.Entry(obj).Property("UsuarioCriacaoId").IsModified = false;
        }
    }
}
