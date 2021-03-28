using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public class ExercicioRepository : IRepositoryBase<Exercicio>
    {
        private readonly HabilitarContext _context;

        public ExercicioRepository(HabilitarContext context) =>
            _context = context;

        public async Task Add(Exercicio obj) =>
            await _context.Exercicio.AddAsync(obj);

        public async Task<bool> Exists<T>(T id) =>
            await _context.Exercicio
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id)) != null;

        public async Task<List<Exercicio>> GetAll() =>
            await _context.Exercicio
            .AsNoTracking()
            .ToListAsync();

        public async Task<Exercicio> GetById<T>(T id) =>
            await _context.Exercicio
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id));

        public void Remove(Exercicio obj) =>
            _context.Exercicio.Remove(obj);

        public void Update(Exercicio obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property("DataCriacao").IsModified = false;
            _context.Entry(obj).Property("UsuarioCriacaoId").IsModified = false;
        }
    }
}
