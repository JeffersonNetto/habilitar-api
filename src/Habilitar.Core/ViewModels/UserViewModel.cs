using System;
using System.Collections.Generic;

namespace Habilitar.Core.ViewModels
{
    public record CreateUserViewModel : ViewModelBaseForInsert
    {        
        public string Email { get; init; }
        public string Password { get; init; } = "123456";
        public string UserName { get; init; }        
        public string PhoneNumber { get; init; }        
        public string Nome { get; init; }
        public string Sobrenome { get; init; }
        public DateTime DataNascimento { get; init; }
        public string Sexo { get; init; }
        public string Cpf { get; init; }
        public string IntegracaoId { get; init; }
        public string Role { get; init; }
    }

    public record LoginUserViewModel
    {        
        public string Email { get; init; }        
        public string Password { get; init; }
    }

    public record UserViewModel
    {
        public Guid Id { get; init; }
        public string Email { get; init; }
        public string UserName { get; init; }        
        public IEnumerable<ClaimViewModel> Claims { get; init; }
    }

    public record LoginResponseViewModel
    {
        public string AccessToken { get; init; }
        public double ExpiresIn { get; init; }
        public UserViewModel User { get; init; }
    }

    public record ClaimViewModel
    {
        public string Value { get; init; }
        public string Type { get; init; }
    }
}
