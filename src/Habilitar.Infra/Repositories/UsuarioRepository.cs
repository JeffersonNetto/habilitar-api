using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Habilitar.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<User> _userManager;

        public UsuarioRepository(UserManager<User> userManager) 
        {            
            _userManager = userManager;                        
        } 

        public async Task<IdentityResult> Adicionar(User user) =>
            await _userManager.CreateAsync(user, user.PasswordHash);        

        public async Task<IdentityResult> VincularPerfil(User user, string newRole, string oldRole = null)
        {            
            if(oldRole is not null)
                await _userManager.RemoveFromRoleAsync(user, oldRole);

            return await _userManager.AddToRoleAsync(user, newRole);
        }
                    
        public async Task<IdentityResult> Atualizar(User user) =>                    
            await _userManager.UpdateAsync(user);                    
            
        public async Task<IEnumerable<User>> Obter() =>
            await _userManager.Users.ToListAsync();

        public async Task<IEnumerable<User>> ObterPorRole(Core.Enums.Role role) =>
            await _userManager.GetUsersInRoleAsync(role.ToString());

        public async Task<User> ObterPorEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            user.Role = await ObterRole(user);

            return user;
        }

        public async Task<string> ObterRole(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            return roles.FirstOrDefault();            
        }            

        public async Task<User> ObterPorId(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            user.Role = await ObterRole(user);

            return user;
        }
            
        public async Task<IdentityResult> Remover(User user) => 
            await _userManager.DeleteAsync(user);
        
        public async Task<IdentityResult> AlterarSenha(User user, string senhaAtual, string novaSenha) =>
            await _userManager.ChangePasswordAsync(user, senhaAtual, novaSenha);

        public async Task<bool> UsuarioExiste(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());            

            return user != null;
        }

        public void Dispose() => _userManager?.Dispose();
    }
}
