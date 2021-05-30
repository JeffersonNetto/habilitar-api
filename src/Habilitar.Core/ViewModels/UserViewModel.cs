using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Habilitar.Core.ViewModels
{
    public class RegisterUserViewModel : ViewModelBaseForInsert
    {        
        public string Email { get; set; }        
        public string Password { get; set; }        
        public string ConfirmPassword { get; set; }        
        public string UserName { get; set; }        
        public string PhoneNumber { get; set; }        
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public string IntegracaoId { get; set; }
    }

    public class EditUserViewModel
    {
        public string Email { get; set; }               
        public string UserName { get; set; }        
        public string PhoneNumber { get; set; }        
    }

    public class LoginUserViewModel
    {        
        public string Email { get; set; }        
        public string Password { get; set; }
    }

    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<ClaimViewModel> Claims { get; set; }
    }

    public class LoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserViewModel User { get; set; }
    }

    public class ClaimViewModel
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
