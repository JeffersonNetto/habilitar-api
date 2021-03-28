using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public class PerfilRepository : IRepositoryBase<Perfil>
    {
        private readonly HabilitarContext _context;

        public PerfilRepository(HabilitarContext context) =>
            _context = context;

        public async Task Add(Perfil obj) =>
            await _context.Perfil.AddAsync(obj);

        public async Task<bool> Exists<T>(T id) =>
            await _context.Perfil
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id)) != null;

        public async Task<List<Perfil>> GetAll() =>
            await _context.Perfil
            .AsNoTracking()
            .ToListAsync();

        public async Task<Perfil> GetById<T>(T id) =>
            await _context.Perfil
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id));

        public void Remove(Perfil obj) =>
            _context.Perfil.Remove(obj);

        public void Update(Perfil obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property("DataCriacao").IsModified = false;
            _context.Entry(obj).Property("UsuarioCriacaoId").IsModified = false;
        }
    }
}
