using Habilitar.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar.Core.Repositories
{
    public interface IUsuarioRepository : IDisposable
    {
        Task<IEnumerable<User>> Obter();
        Task<User> ObterPorEmail(string email);
        Task<User> ObterPorId(Guid id);
        Task<IdentityResult> Adicionar(User user);
        Task<IdentityResult> VincularPerfil(User user, string newRole, string oldRole = null);
        Task<IdentityResult> Atualizar(User user);
        Task<IdentityResult> Remover(User user);
        Task<IdentityResult> AlterarSenha(User user, string currentPassword, string newPassword);
        Task<string> ObterRole(User user);
    }
}
