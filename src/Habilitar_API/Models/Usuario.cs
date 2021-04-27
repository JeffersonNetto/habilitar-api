﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Habilitar_API.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            EmpresaUsuarioAtualizacao = new HashSet<Empresa>();
            EmpresaUsuarioCriacao = new HashSet<Empresa>();
            ExercicioGrupoUsuarioAtualizacao = new HashSet<ExercicioGrupo>();
            ExercicioGrupoUsuarioCriacao = new HashSet<ExercicioGrupo>();
            ExercicioMetricaUsuarioAtualizacao = new HashSet<ExercicioMetrica>();
            ExercicioMetricaUsuarioCriacao = new HashSet<ExercicioMetrica>();
            ExercicioUsuarioAtualizacao = new HashSet<Exercicio>();
            ExercicioUsuarioCriacao = new HashSet<Exercicio>();
            FuncaoUsuarioAtualizacao = new HashSet<Funcao>();
            FuncaoUsuarioCriacao = new HashSet<Funcao>();
            GrupoUsuarioAtualizacao = new HashSet<Grupo>();
            GrupoUsuarioCriacao = new HashSet<Grupo>();
            IntervaloUsuarioAtualizacao = new HashSet<Intervalo>();
            IntervaloUsuarioCriacao = new HashSet<Intervalo>();
            LogAcesso = new HashSet<LogAcesso>();
            LogErro = new HashSet<LogErro>();
            MetaFisioterapeuta = new HashSet<Meta>();
            MetaUsuarioAtualizacao = new HashSet<Meta>();
            MetaUsuarioCriacao = new HashSet<Meta>();
            MetricaUsuarioAtualizacao = new HashSet<Metrica>();
            MetricaUsuarioCriacao = new HashSet<Metrica>();
            PacienteMetaFisioterapeuta = new HashSet<PacienteMeta>();
            PacienteMetaUsuarioAtualizacao = new HashSet<PacienteMeta>();
            PacienteMetaUsuarioCriacao = new HashSet<PacienteMeta>();
            PerfilFuncao = new HashSet<PerfilFuncao>();
            PerfilUsuarioAtualizacao = new HashSet<Perfil>();
            PerfilUsuarioCriacao = new HashSet<Perfil>();
            PessoaUsuarioAtualizacao = new HashSet<Pessoa>();
            PessoaUsuarioCriacao = new HashSet<Pessoa>();
            UnidadeUsuarioAtualizacao = new HashSet<Unidade>();
            UnidadeUsuarioCriacao = new HashSet<Unidade>();
            UsuarioPerfilUsuario = new HashSet<UsuarioPerfil>();
            UsuarioPerfilUsuarioCriacao = new HashSet<UsuarioPerfil>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int? PessoaId { get; set; }
        public int? UnidadeId { get; set; }
        public bool Profissional { get; set; }
        public bool Fisioterapeuta { get; set; }
        public string Conselho { get; set; }
        public string Ip { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioCriacaoId { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public int? UsuarioAtualizacaoId { get; set; }

        [NotMapped]
        public string Token { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual Unidade Unidade { get; set; }
        public virtual ICollection<Empresa> EmpresaUsuarioAtualizacao { get; set; }
        public virtual ICollection<Empresa> EmpresaUsuarioCriacao { get; set; }
        public virtual ICollection<ExercicioGrupo> ExercicioGrupoUsuarioAtualizacao { get; set; }
        public virtual ICollection<ExercicioGrupo> ExercicioGrupoUsuarioCriacao { get; set; }
        public virtual ICollection<ExercicioMetrica> ExercicioMetricaUsuarioAtualizacao { get; set; }
        public virtual ICollection<ExercicioMetrica> ExercicioMetricaUsuarioCriacao { get; set; }
        public virtual ICollection<Exercicio> ExercicioUsuarioAtualizacao { get; set; }
        public virtual ICollection<Exercicio> ExercicioUsuarioCriacao { get; set; }
        public virtual ICollection<Funcao> FuncaoUsuarioAtualizacao { get; set; }
        public virtual ICollection<Funcao> FuncaoUsuarioCriacao { get; set; }
        public virtual ICollection<Grupo> GrupoUsuarioAtualizacao { get; set; }
        public virtual ICollection<Grupo> GrupoUsuarioCriacao { get; set; }
        public virtual ICollection<Intervalo> IntervaloUsuarioAtualizacao { get; set; }
        public virtual ICollection<Intervalo> IntervaloUsuarioCriacao { get; set; }
        public virtual ICollection<LogAcesso> LogAcesso { get; set; }
        public virtual ICollection<LogErro> LogErro { get; set; }
        public virtual ICollection<Meta> MetaFisioterapeuta { get; set; }
        public virtual ICollection<Meta> MetaUsuarioAtualizacao { get; set; }
        public virtual ICollection<Meta> MetaUsuarioCriacao { get; set; }
        public virtual ICollection<Metrica> MetricaUsuarioAtualizacao { get; set; }
        public virtual ICollection<Metrica> MetricaUsuarioCriacao { get; set; }
        public virtual ICollection<PacienteMeta> PacienteMetaFisioterapeuta { get; set; }
        public virtual ICollection<PacienteMeta> PacienteMetaUsuarioAtualizacao { get; set; }
        public virtual ICollection<PacienteMeta> PacienteMetaUsuarioCriacao { get; set; }
        public virtual ICollection<PerfilFuncao> PerfilFuncao { get; set; }
        public virtual ICollection<Perfil> PerfilUsuarioAtualizacao { get; set; }
        public virtual ICollection<Perfil> PerfilUsuarioCriacao { get; set; }
        public virtual ICollection<Pessoa> PessoaUsuarioAtualizacao { get; set; }
        public virtual ICollection<Pessoa> PessoaUsuarioCriacao { get; set; }
        public virtual ICollection<Unidade> UnidadeUsuarioAtualizacao { get; set; }
        public virtual ICollection<Unidade> UnidadeUsuarioCriacao { get; set; }
        public virtual ICollection<UsuarioPerfil> UsuarioPerfilUsuario { get; set; }
        public virtual ICollection<UsuarioPerfil> UsuarioPerfilUsuarioCriacao { get; set; }
    }
}