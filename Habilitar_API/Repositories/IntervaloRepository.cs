using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public class IntervaloRepository : IRepositoryBase<Intervalo>
    {
        private readonly HabilitarContext _context;

        public IntervaloRepository(HabilitarContext context) =>
            _context = context;

        public async Task Add(Intervalo obj) =>
            await _context.Intervalo.AddAsync(obj);

        public async Task<bool> Exists<T>(T id) =>
            await _context.Intervalo
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id)) != null;

        public async Task<List<Intervalo>> GetAll() =>
            await _context.Intervalo
            .AsNoTracking()
            .ToListAsync();

        public async Task<Intervalo> GetById<T>(T id) =>
            await _context.Intervalo
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id));

        public void Remove(Intervalo obj) =>
            _context.Intervalo.Remove(obj);

        public void Update(Intervalo obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property("DataCriacao").IsModified = false;
            _context.Entry(obj).Property("UsuarioCriacaoId").IsModified = false;
        }
    }
}
