// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Habilitar.Core.Models
{
    public partial class PacienteMetaDiaria
    {
        public PacienteMetaDiaria()
        {
            PacienteMetaDiariaLog = new HashSet<PacienteMetaDiariaLog>();
        }

        public int Id { get; set; }
        public int PacienteMetaId { get; set; }
        public DateTime Data { get; set; }
        public int MetricaQtd { get; set; }
        public int? QtdRealizado { get; set; }
        public string Ip { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public virtual PacienteMeta PacienteMeta { get; set; }
        public virtual ICollection<PacienteMetaDiariaLog> PacienteMetaDiariaLog { get; set; }
    }
}