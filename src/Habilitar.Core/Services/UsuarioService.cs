using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Uow;
using System;
using System.Threading.Tasks;

namespace Habilitar.Core.Services
{
    public interface IUsuarioService : IDisposable
    {
        Task<bool> Adicionar(User obj);
        Task<bool> Atualizar(User obj);
        Task<bool> Remover(Guid id);
    }
    public class UsuarioService : ServiceBase, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(
            INotificador notificador,
            IUnitOfWork uow,
            IUsuarioRepository usuarioRepository) : base(notificador, uow)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Adicionar(User obj)
        {
            var result = await _usuarioRepository.Adicionar(obj);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    Notificar(error.Description);

                return false;
            }

            var user = await _usuarioRepository.ObterPorEmail(obj.Email);

            await _usuarioRepository.VincularPerfil(user, "Admin");

            return true;
        }

        public async Task<bool> Atualizar(User obj)
        {
            var user = await _usuarioRepository.ObterPorId(obj.Id);

            if (user == null)
            {
                Notificar("Usuário não existe na base de dados");
                return false;
            }            

            var result = await _usuarioRepository.Atualizar(obj);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    Notificar(error.Description);

                return false;
            }

            return true;            
        }
               
        public async Task<bool> Remover(Guid id)
        {
            var user = await _usuarioRepository.ObterPorId(id);

            if (user == null)
            {
                Notificar("Usuário não existe na base de dados");
                return false;
            }

            var result = await _usuarioRepository.Remover(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    Notificar(error.Description);

                return false;
            }

            return true;
        }

        public void Dispose() => _usuarioRepository?.Dispose();
    }
}
