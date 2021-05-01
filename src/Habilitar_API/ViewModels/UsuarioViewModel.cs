using System.Collections.Generic;

namespace Habilitar_API.ViewModels
{
    public class UsuarioViewModel : ViewModelBase
    {
        public string Login { get; set; }        
        public int? PessoaId { get; set; }
        public int? UnidadeId { get; set; }
        public bool Profissional { get; set; }
        public bool Fisioterapeuta { get; set; }
        public string Conselho { get; set; }
        public string Token { get; set; }
        public virtual ICollection<UsuarioPerfilViewModel> UsuarioPerfilUsuario { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
        public virtual UnidadeViewModel Unidade { get; set; }
    }
}
