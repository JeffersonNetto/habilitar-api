﻿using System;

namespace Habilitar_API.ViewModels
{
    public class PessoaViewModel : ViewModelBase
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string IntegracaoId { get; set; }
        public string Email { get; set; }
    }
}
