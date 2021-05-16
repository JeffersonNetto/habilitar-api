using Habilitar.Core.Helpers;
using Habilitar.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Habilitar.Api.Controllers
{
    public class UsuarioController : MainController
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsuarioController(
            INotificador notificador,
            IUser user, 
            UserManager<IdentityUser> userManager) : base(notificador, user)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            CustomResponse(await _userManager.Users.ToListAsync());
    }
}
