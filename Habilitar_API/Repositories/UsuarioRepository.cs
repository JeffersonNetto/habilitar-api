using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public class UsuarioRepository : IRepositoryBase<Usuario>
    {
        private readonly HabilitarContext _context;

        public UsuarioRepository(HabilitarContext context) =>
            _context = context;

        public async Task Add(Usuario obj) =>
            await _context.Usuario.AddAsync(obj);

        public async Task<bool> Exists<T>(T id) =>
            await _context.Usuario
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id)) != null;

        public async Task<List<Usuario>> GetAll() =>
            await _context.Usuario
            .AsNoTracking()
            .ToListAsync();

        public async Task<Usuario> GetById<T>(T id) =>
            await _context.Usuario
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id));

        public void Remove(Usuario obj) =>
            _context.Usuario.Remove(obj);

        public void Update(Usuario obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property("DataCriacao").IsModified = false;
            _context.Entry(obj).Property("UsuarioCriacaoId").IsModified = false;
        }
    }    
}
