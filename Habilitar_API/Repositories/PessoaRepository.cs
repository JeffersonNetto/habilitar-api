using Habilitar_API.Data;
using Habilitar_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Repositories
{
    public class PessoaRepository : IRepositoryBase<Pessoa>
    {
        private readonly HabilitarContext _context;

        public PessoaRepository(HabilitarContext context) =>
            _context = context;

        public async Task Add(Pessoa obj) =>
            await _context.Pessoa.AddAsync(obj);

        public async Task<bool> Exists<T>(T id) =>
            await _context.Pessoa
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id)) != null;

        public async Task<List<Pessoa>> GetAll() =>
            await _context.Pessoa
            .AsNoTracking()
            .ToListAsync();

        public async Task<Pessoa> GetById<T>(T id) =>
            await _context.Pessoa
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id.Equals(id));

        public void Remove(Pessoa obj) =>
            _context.Pessoa.Remove(obj);

        public void Update(Pessoa obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property("DataCriacao").IsModified = false;
            _context.Entry(obj).Property("UsuarioCriacaoId").IsModified = false;
        }
    }    
}
