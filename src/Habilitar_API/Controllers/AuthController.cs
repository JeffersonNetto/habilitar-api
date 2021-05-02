using FluentValidation.Results;
using Habilitar_API.Services;
using Habilitar_API.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Controllers
{
    public class AuthController : MainController
    {
        private readonly INotificador _notificador;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(
            INotificador notificador,
            SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager) : base (notificador)
        {
            _notificador = notificador;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<RegisterViewModel>> Registrar(RegisterViewModel register)
        {
            var usuario = new IdentityUser
            {
                UserName = register.Login,
                Email = register.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(usuario, register.ConfirmPassword);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(usuario, false);
                return CustomSuccessResponse(200, "", register);
            }
            else
            {                                
                foreach (var error in result.Errors)
                    NotificarErro(error.Description);

                return CustomResponse("", register);
            }
        }

        [HttpPost("entrar")]
        public async Task<ActionResult<LoginViewModel>> Login(LoginViewModel login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Login, login.Senha, false, true);

            if (result.Succeeded)
                return CustomSuccessResponse(200, null, login);
            else if (result.IsLockedOut)
            {
                var erros = new List<ValidationFailure>
                {
                    new ValidationFailure("", "")
                };

                return CustomErrorResponse(400, "", erros);
            }

            return CustomErrorResponse(400, "Usuário ou Senha incorretos");
        }
    }
}
