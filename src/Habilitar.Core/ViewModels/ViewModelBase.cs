using System;

namespace Habilitar.Core.ViewModels
{
    public abstract class ViewModelBase
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioCriacaoId { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public int? UsuarioAtualizacaoId { get; set; }
    }
}
