using Habilitar_API.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Habilitar_API.Services
{
    public class TokenService
    {
        enum TokenType
        {
            Access,
            Refresh
        }
        
        public static string GenerateToken(Usuario usuario, DateTime expires)
        {
            string secret = "algumsegredoaqui";
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Pessoa.Nome),
                    new Claim(ClaimTypes.Surname, usuario.Pessoa.Sobrenome),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Pessoa.Cpf),
                    new Claim(ClaimTypes.Email, usuario.Pessoa.Email),
                    new Claim(ClaimTypes.MobilePhone, usuario.Pessoa.Telefone),
                    new Claim(ClaimTypes.DateOfBirth, usuario.Pessoa.DataNascimento.ToShortDateString()),
                    new Claim(ClaimTypes.Gender, usuario.Pessoa.Sexo),
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "api.habilitar.com",
                Audience = "habilitar.com"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
