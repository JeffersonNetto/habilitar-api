using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public class FuncaoRepository : IRepositoryBase<Funcao>
    {
        private readonly HabilitarContext _context;

        public FuncaoRepository(HabilitarContext context) =>
            _context = context;

        public async Task Add(Funcao obj) =>
            await _context.Funcao.AddAsync(obj);

        public async Task<bool> Exists<T>(T id) =>
            await _context.Funcao
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id)) != null;

        public async Task<List<Funcao>> GetAll() =>
            await _context.Funcao
            .AsNoTracking()
            .ToListAsync();

        public async Task<Funcao> GetById<T>(T id) =>
            await _context.Funcao
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id));

        public void Remove(Funcao obj) =>
            _context.Funcao.Remove(obj);

        public void Update(Funcao obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property("DataCriacao").IsModified = false;
            _context.Entry(obj).Property("UsuarioCriacaoId").IsModified = false;
        }
    }
}
