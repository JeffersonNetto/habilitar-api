using Habilitar.Core.Services;
using Habilitar.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Habilitar.Api.Controllers
{
    [AllowAnonymous]
    public class AuthController : MainController
    {
        private readonly IUsuarioService _usuarioService;

        public AuthController(
            IUsuarioService usuarioService,
            INotificador notificador) : base(notificador) => _usuarioService = usuarioService;

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            return CustomResponse(await _usuarioService.Registrar(registerUser));            
        }

        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            return CustomResponse(await _usuarioService.Login(loginUser));
        }        
    }
}
