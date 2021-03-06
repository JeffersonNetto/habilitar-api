// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Habilitar.Core.Models
{
    public partial class Intervalo
    {
        public Intervalo()
        {
            Meta = new HashSet<Meta>();
            PacienteMeta = new HashSet<PacienteMeta>();
        }

        public short Id { get; set; }
        public string Descricao { get; set; }
        public string Ip { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public Guid UsuarioCriacaoId { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public Guid? UsuarioAtualizacaoId { get; set; }

        public virtual ICollection<Meta> Meta { get; set; }
        public virtual ICollection<PacienteMeta> PacienteMeta { get; set; }
    }
}