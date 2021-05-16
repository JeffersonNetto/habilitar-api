using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Uow;
using Habilitar.Core.Validators;
using System;
using System.Threading.Tasks;

namespace Habilitar.Core.Services
{
    public interface IPessoaService : IDisposable
    {
        Task<bool> Adicionar(Pessoa pessoa);
        Task<bool> Atualizar(Pessoa pessoa);
        Task<bool> Remover(int id);
        Task<bool> Remover(string userId);
    }
    public class PessoaService : ServiceBase, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;        

        public PessoaService(
            IPessoaRepository pessoaRepository, 
            INotificador notificador, 
            IUnitOfWork uow) : base(notificador, uow) => _pessoaRepository = pessoaRepository;                    

        public async Task<bool> Adicionar(Pessoa pessoa)
        {
            if (!await ExecutarValidacao(new PessoaValidator(), pessoa))
                return false;

            await _pessoaRepository.Add(pessoa);
            await Commit();

            return true;
        }

        public async Task<bool> Atualizar(Pessoa pessoa)
        {
            if (!await ExecutarValidacao(new PessoaValidator(), pessoa))
                return false;

            _pessoaRepository.Update(pessoa);
            await Commit();

            return true;
        }
        
        public async Task<bool> Remover(int id)
        {
            var pessoa = await _pessoaRepository.GetById(id);

            if (pessoa == null)
                Notificar($"Nenhuma pessoa encontrada para o Id {id}");

            _pessoaRepository.Remove(pessoa);
            await Commit();

            return true;
        }
        
        public async Task<bool> Remover(string userId)
        {
            var pessoa = await _pessoaRepository.GetByUserId(userId);
            
            _pessoaRepository.Remove(pessoa);
            await Commit();

            return true;
        }

        public void Dispose() => _pessoaRepository?.Dispose();
    }
}
