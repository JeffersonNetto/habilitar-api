using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Habilitar.Infra.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(HabilitarContext context) : base(context) { }

        public Task<Pessoa> GetByUserId(Guid userId) =>        
            _context.Pessoa.SingleAsync(_ => _.UserId == userId);        
    }    
}
