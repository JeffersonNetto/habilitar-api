using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public class MetricaRepository : IRepositoryBase<Metrica>
    {
        private readonly HabilitarContext _context;

        public MetricaRepository(HabilitarContext context) =>
            _context = context;

        public async Task Add(Metrica obj) =>
            await _context.Metrica.AddAsync(obj);

        public async Task<bool> Exists<T>(T id) =>
            await _context.Metrica
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id)) != null;

        public async Task<List<Metrica>> GetAll() =>
            await _context.Metrica
            .AsNoTracking()
            .ToListAsync();

        public async Task<Metrica> GetById<T>(T id) =>
            await _context.Metrica
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id));

        public void Remove(Metrica obj) =>
            _context.Metrica.Remove(obj);

        public void Update(Metrica obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property("DataCriacao").IsModified = false;
            _context.Entry(obj).Property("UsuarioCriacaoId").IsModified = false;
        }
    }    
}
