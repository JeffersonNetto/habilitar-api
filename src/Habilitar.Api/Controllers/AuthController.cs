using AutoMapper;
using Habilitar.Core.Helpers;
using Habilitar.Core.Models;
using Habilitar.Core.Services;
using Habilitar.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Habilitar.Api.Controllers
{
    [AllowAnonymous]
    public class AuthController : MainController
    {
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<User> _userManager;        
        private readonly IMapper _mapper;        

        public AuthController(
            INotificador notificador,
            UserManager<User> userManager,
            ILogger<AuthController> logger,
            SignInManager<User> signInManager,
            IOptions<JwtSettings> jwtSettings,            
            IMapper mapper,
            IUser user
            ) : base(notificador, user)
        {
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;            
            _mapper = mapper;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            var result = await _userManager.CreateAsync(new User
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email,
                PhoneNumber = registerUser.PhoneNumber,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            }, registerUser.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    NotificarErro(error.Description);

                return CustomResponse();
            }
            
            var user = await _userManager.FindByEmailAsync(registerUser.Email);
            
            await _userManager.AddToRoleAsync(user, "Admin");            

            //await _signInManager.SignInAsync(user, false);

            return CustomResponse();
        }

        [HttpPost("entrar")]        
        public async Task<ActionResult<LoginResponseViewModel>> Login(LoginUserViewModel loginUser)
        {
            var user = await _userManager.FindByEmailAsync(loginUser.Email);

            if (user == null)
            {
                NotificarErro("Usuário não existe na base de dados");
                return CustomResponse();
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, loginUser.Password, false, true);

            if (result.IsLockedOut)
            {
                NotificarErro("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse();
            }
            if (!result.Succeeded)
            {
                NotificarErro("Usuário ou Senha incorretos");
                return CustomResponse();
            }

            _logger.LogInformation("Usuario " + loginUser.Email + " logado com sucesso");

            return CustomResponse(await GenerateToken(user));
        }

        [HttpGet("remover/{id:guid}")]        
        public async Task<ActionResult> Remover(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                NotificarErro("Usuário não existe na base de dados");
                return CustomResponse();
            }            

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)                            
            {
                foreach (var error in result.Errors)
                    NotificarErro(error.Description);

                return CustomResponse();
            }

            return CustomResponse("Usuário excluído com sucesso");
        }

        [HttpPut("editar/{id:guid}")]
        public async Task<ActionResult<LoginResponseViewModel>> Editar(Guid id, EditUserViewModel editUser)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                NotificarErro("Usuário não existe na base de dados");
                return CustomResponse();
            }            

            user.Email = editUser.Email;
            user.UserName = editUser.UserName;
            user.PhoneNumber = editUser.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    NotificarErro(error.Description);

                return CustomResponse();
            }

            return CustomResponse("Usuário editado com sucesso");
        }

        private async Task<LoginResponseViewModel> GenerateToken(User user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
                claims.Add(new Claim("role", userRole));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_jwtSettings.Expires).TotalSeconds,
                User = new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
