using System;

namespace Habilitar.Core.ViewModels
{
    public abstract class ViewModelBaseForInsert
    {        
        public string Ip { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioCriacaoId { get; set; }     
    }

    public abstract class ViewModelBaseForUpdate : ViewModelBaseForInsert
    {
        public int Id { get; set; }        
        public DateTime? DataAtualizacao { get; set; }
        public int? UsuarioAtualizacaoId { get; set; }
    }
}
