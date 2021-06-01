using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<User> _userManager;
        public UsuarioRepository(UserManager<User> userManager) => _userManager = userManager;        

        public async Task<IdentityResult> Adicionar(User user) =>
            await _userManager.CreateAsync(user, user.PasswordHash);        

        public async Task<IdentityResult> VincularPerfil(User user, string role) =>
            await _userManager.AddToRoleAsync(user, role);
        
        public async Task<IdentityResult> Atualizar(User user) =>
            await _userManager.UpdateAsync(user);

        public async Task<IEnumerable<User>> Obter() =>
            await _userManager.Users.ToListAsync();

        public async Task<User> ObterPorEmail(string email) =>
            await _userManager.FindByEmailAsync(email);

        public async Task<User> ObterPorId(Guid id) =>
            await _userManager.FindByIdAsync(id.ToString());

        public async Task<IdentityResult> Remover(User user) => 
            await _userManager.DeleteAsync(user);
        public void Dispose() => _userManager?.Dispose();    

        public async Task<IdentityResult> AlterarSenha(User user, string senhaAtual, string novaSenha) =>
            await _userManager.ChangePasswordAsync(user, senhaAtual, novaSenha);        
    }
}
