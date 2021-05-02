﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Habilitar_API.Models
{
    [Index(nameof(UsuarioAtualizacaoId), Name = "IX_Funcao_UsuarioAtualizacaoId")]
    [Index(nameof(UsuarioCriacaoId), Name = "IX_Funcao_UsuarioCriacaoId")]
    public partial class Funcao
    {
        public Funcao()
        {
            PerfilFuncao = new HashSet<PerfilFuncao>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }
        [StringLength(150)]
        public string Observacao { get; set; }
        public bool Ativo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCriacao { get; set; }
        public int UsuarioCriacaoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        public int? UsuarioAtualizacaoId { get; set; }

        [ForeignKey(nameof(UsuarioAtualizacaoId))]
        [InverseProperty(nameof(Usuario.FuncaoUsuarioAtualizacao))]
        public virtual Usuario UsuarioAtualizacao { get; set; }
        [ForeignKey(nameof(UsuarioCriacaoId))]
        [InverseProperty(nameof(Usuario.FuncaoUsuarioCriacao))]
        public virtual Usuario UsuarioCriacao { get; set; }
        [InverseProperty("Funcao")]
        public virtual ICollection<PerfilFuncao> PerfilFuncao { get; set; }
    }
}