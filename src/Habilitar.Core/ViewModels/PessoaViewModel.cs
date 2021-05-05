using System;

namespace Habilitar.Core.ViewModels
{
    public class PessoaViewModelInsert : ViewModelBaseForInsert
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public string IntegracaoId { get; set; }
    }

    public class PessoaViewModelUpdate : ViewModelBaseForUpdate
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public string IntegracaoId { get; set; }
    }
}
