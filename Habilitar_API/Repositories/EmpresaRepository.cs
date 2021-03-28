using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public class EmpresaRepository : IRepositoryBase<Empresa>
    {
        private readonly HabilitarContext _context;

        public EmpresaRepository(HabilitarContext context) =>
            _context = context;

        public async Task Add(Empresa obj) =>
            await _context.Empresa.AddAsync(obj);

        public async Task<bool> Exists<T>(T id) =>
            await _context.Empresa
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id)) != null;

        public async Task<List<Empresa>> GetAll() =>
            await _context.Empresa
            .AsNoTracking()
            .ToListAsync();

        public async Task<Empresa> GetById<T>(T id) =>
            await _context.Empresa
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id));

        public void Remove(Empresa obj) =>
            _context.Empresa.Remove(obj);

        public void Update(Empresa obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property("DataCriacao").IsModified = false;
            _context.Entry(obj).Property("UsuarioCriacaoId").IsModified = false;
        }
    }    
}
