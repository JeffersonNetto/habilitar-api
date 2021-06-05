using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Uow;
using Habilitar.Core.ViewModels;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Habilitar.Core.Services
{
    public interface IUsuarioService : IDisposable
    {
        Task<bool> Adicionar(User obj, string role);
        Task<bool> Atualizar(User obj);
        Task<bool> Remover(Guid id);
        Task<bool> AlterarSenha(Guid id, AlterarSenhaViewModel model);
        Task<string> ObterRole(Guid id);
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

        public async Task<bool> Adicionar(User obj, string role)
        {
            var result = await _usuarioRepository.Adicionar(obj);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    Notificar(error.Description);

                return false;
            }

            var user = await _usuarioRepository.ObterPorEmail(obj.Email);

            await _usuarioRepository.VincularPerfil(user, role);

            return true;
        }

        public async Task<bool> Atualizar(User model)
        {            
            var user = await _usuarioRepository.ObterPorId(model.Id);

            if (user == null)
            {
                Notificar("Usuário não existe na base de dados");
                return false;
            }

            await _usuarioRepository.VincularPerfil(user, model.Role, user.Role);

            foreach (PropertyInfo property in typeof(User).GetProperties())            
                property.SetValue(user, property.GetValue(model, null), null);

            user.DataAtualizacao = DateTime.Now;

            var result = await _usuarioRepository.Atualizar(user);

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

        public async Task<bool> AlterarSenha(Guid id, AlterarSenhaViewModel model)
        {
            var user = await _usuarioRepository.ObterPorId(id);

            if (user == null)
            {
                Notificar("Usuário não existe na base de dados");
                return false;
            }

            var result = await _usuarioRepository.AlterarSenha(user, model.SenhaAtual, model.NovaSenha);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    Notificar(error.Description);

                return false;
            }

            return true;
        }

        public async Task<string> ObterRole(Guid id)
        {
            var user = await _usuarioRepository.ObterPorId(id);
            string role = null;

            if (user == null)
                Notificar("Usuário não existe na base de dados");                                                   
            else
                role = await _usuarioRepository.ObterRole(user);

            return role;
        }
    }
}
