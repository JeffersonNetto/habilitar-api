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
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;            

        public AuthController(
            INotificador notificador,            
            UserManager<IdentityUser> userManager,
            ILogger<AuthController> logger,
            SignInManager<IdentityUser> signInManager,
            IOptions<JwtSettings> jwtSettings,
            IPessoaService pessoaService,
            IMapper mapper
            ) : base(notificador)
        {            
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _pessoaService = pessoaService;
            _mapper = mapper;            
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<LoginResponseViewModel>> Registrar(RegisterUserViewModel registerUser)
        {
            var result = await _userManager.CreateAsync(new IdentityUser
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email,
                PhoneNumber = registerUser.PhoneNumber,
                EmailConfirmed = true
            }, registerUser.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    NotificarErro(error.Description);

                return CustomResponse();
            }

            var pessoa = _mapper.Map<Pessoa>(registerUser.Pessoa);
            var user = await _userManager.FindByEmailAsync(registerUser.Email);
            pessoa.UserId = Guid.Parse(user.Id);

            await _userManager.AddToRoleAsync(user, "Admin");

            await _pessoaService.Adicionar(pessoa);                       

            await _signInManager.SignInAsync(user, false);
            
            return CustomResponse(await GenerateToken(user));
        }

        [HttpPost("entrar")]
        public async Task<ActionResult<LoginResponseViewModel>> Login(LoginUserViewModel loginUser)
        {
            var user = await _userManager.FindByEmailAsync(loginUser.Email);

            if(user == null)
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

        private async Task<LoginResponseViewModel> GenerateToken(IdentityUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            //claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
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
                    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
