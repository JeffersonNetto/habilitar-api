﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Habilitar.Core.Models
{
    public partial class Meta
    {
        public Meta()
        {
            PacienteMeta = new HashSet<PacienteMeta>();
        }

        public int Id { get; set; }
        public int ExercicioId { get; set; }
        public int QtdSeries { get; set; }
        public short MetricaId { get; set; }
        public int MetricaQtd { get; set; }
        public short IntervaloId { get; set; }
        public int EmpresaId { get; set; }
        public int? FisioterapeutaId { get; set; }
        public string Ip { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid UsuarioCriacaoId { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public Guid? UsuarioAtualizacaoId { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual Exercicio Exercicio { get; set; }
        public virtual Intervalo Intervalo { get; set; }
        public virtual Metrica Metrica { get; set; }
        public virtual ICollection<PacienteMeta> PacienteMeta { get; set; }
    }
}