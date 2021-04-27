﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Habilitar_API.Models;

#nullable disable

namespace Habilitar_API.Data
{
    public partial class HabilitarContext : DbContext
    {
        public HabilitarContext()
        {
        }

        public HabilitarContext(DbContextOptions<HabilitarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Exercicio> Exercicio { get; set; }
        public virtual DbSet<ExercicioGrupo> ExercicioGrupo { get; set; }
        public virtual DbSet<ExercicioMetrica> ExercicioMetrica { get; set; }
        public virtual DbSet<Funcao> Funcao { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Intervalo> Intervalo { get; set; }
        public virtual DbSet<LogAcesso> LogAcesso { get; set; }
        public virtual DbSet<LogErro> LogErro { get; set; }
        public virtual DbSet<Meta> Meta { get; set; }
        public virtual DbSet<Metrica> Metrica { get; set; }
        public virtual DbSet<PacienteMeta> PacienteMeta { get; set; }
        public virtual DbSet<PacienteMetaDiaria> PacienteMetaDiaria { get; set; }
        public virtual DbSet<PacienteMetaDiariaLog> PacienteMetaDiariaLog { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<PerfilFuncao> PerfilFuncao { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Unidade> Unidade { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioPerfil> UsuarioPerfil { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioAtualizacao)
                    .WithMany(p => p.EmpresaUsuarioAtualizacao)
                    .HasForeignKey(d => d.UsuarioAtualizacaoId)
                    .HasConstraintName("FK_Empresa_UsuarioAtualizacao");

                entity.HasOne(d => d.UsuarioCriacao)
                    .WithMany(p => p.EmpresaUsuarioCriacao)
                    .HasForeignKey(d => d.UsuarioCriacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empresa_UsuarioCriacao");
            });

            modelBuilder.Entity<Exercicio>(entity =>
            {
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomePopular)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioAtualizacao)
                    .WithMany(p => p.ExercicioUsuarioAtualizacao)
                    .HasForeignKey(d => d.UsuarioAtualizacaoId)
                    .HasConstraintName("FK_Exercicio_UsuarioAtualizacao");

                entity.HasOne(d => d.UsuarioCriacao)
                    .WithMany(p => p.ExercicioUsuarioCriacao)
                    .HasForeignKey(d => d.UsuarioCriacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exercicio_UsuarioCriacao");
            });

            modelBuilder.Entity<ExercicioGrupo>(entity =>
            {
                entity.HasKey(e => new { e.ExercicioId, e.GrupoId });

                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exercicio)
                    .WithMany(p => p.ExercicioGrupo)
                    .HasForeignKey(d => d.ExercicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExercicioGrupo_Exercicio");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.ExercicioGrupo)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExercicioGrupo_Grupo");

                entity.HasOne(d => d.UsuarioAtualizacao)
                    .WithMany(p => p.ExercicioGrupoUsuarioAtualizacao)
                    .HasForeignKey(d => d.UsuarioAtualizacaoId)
                    .HasConstraintName("FK_ExercicioGrupo_UsuarioAtualizacao");

                entity.HasOne(d => d.UsuarioCriacao)
                    .WithMany(p => p.ExercicioGrupoUsuarioCriacao)
                    .HasForeignKey(d => d.UsuarioCriacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExercicioGrupo_UsuarioCriacao");
            });

            modelBuilder.Entity<ExercicioMetrica>(entity =>
            {
                entity.HasKey(e => new { e.ExercicioId, e.MetricaId });

                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exercicio)
                    .WithMany(p => p.ExercicioMetrica)
                    .HasForeignKey(d => d.ExercicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExercicioMetrica_Exercicio");

                entity.HasOne(d => d.Metrica)
                    .WithMany(p => p.ExercicioMetrica)
                    .HasForeignKey(d => d.MetricaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExercicioMetrica_Metrica");

                entity.HasOne(d => d.UsuarioAtualizacao)
                    .WithMany(p => p.ExercicioMetricaUsuarioAtualizacao)
                    .HasForeignKey(d => d.UsuarioAtualizacaoId)
                    .HasConstraintName("FK_ExercicioMetrica_UsuarioAtualizacao");

                entity.HasOne(d => d.UsuarioCriacao)
                    .WithMany(p => p.ExercicioMetricaUsuarioCriacao)
                    .HasForeignKey(d => d.UsuarioCriacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExercicioMetrica_UsuarioCriacao");
            });

            modelBuilder.Entity<Funcao>(entity =>
            {
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioAtualizacao)
                    .WithMany(p => p.FuncaoUsuarioAtualizacao)
                    .HasForeignKey(d => d.UsuarioAtualizacaoId)
                    .HasConstraintName("FK_Funcao_UsuarioAtualizacao");

                entity.HasOne(d => d.UsuarioCriacao)
                    .WithMany(p => p.FuncaoUsuarioCriacao)
                    .HasForeignKey(d => d.UsuarioCriacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcao_UsuarioCriacao");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao).HasMaxLength(200);

                entity.HasOne(d => d.UsuarioAtualizacao)
                    .WithMany(p => p.GrupoUsuarioAtualizacao)
                    .HasForeignKey(d => d.UsuarioAtualizacaoId)
                    .HasConstraintName("FK_Grupo_UsuarioAtualizacao");

                entity.HasOne(d => d.UsuarioCriacao)
                    .WithMany(p => p.GrupoUsuarioCriacao)
                    .HasForeignKey(d => d.UsuarioCriacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupo_UsuarioCriacao");
            });

            modelBuilder.Entity<Intervalo>(entity =>
            {
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioAtualizacao)
                    .WithMany(p => p.IntervaloUsuarioAtualizacao)
                    .HasForeignKey(d => d.UsuarioAtualizacaoId)
                    .HasConstraintName("FK_Intervalo_UsuarioAtualizacao");

                entity.HasOne(d => d.UsuarioCriacao)
                    .WithMany(p => p.IntervaloUsuarioCriacao)
                    .HasForeignKey(d => d.UsuarioCriacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Intervalo_UsuarioCriacao");
            });

            modelBuilder.Entity<LogAcesso>(entity =>
            {
                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.LogAcesso)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogAcesso_Usuario");
            });

            modelBuilder.Entity<LogErro>(entity =>
            {
                entity.Property(e => e.Acao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Erro)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tela)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.LogErro)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_LogErro_Usuario");
            });

            modelBuilder.Entity<Meta>(entity =>
            {
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Meta)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meta_Empresa");

                entity.HasOne(d => d.Exercicio)
                    .WithMany(p => p.Meta)
                    .HasForeignKey(d => d.ExercicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meta_Exercicio");

                entity.HasOne(d => d.Fisioterapeuta)
                    .WithMany(p => p.MetaFisioterapeuta)
                    .HasForeignKey(d => d.FisioterapeutaId)
                    .HasConstraintName("FK_Meta_Fisioterapeuta");

                entity.HasOne(d => d.Intervalo)
                    .WithMany(p => p.Meta)
                    .HasForeignKey(d => d.IntervaloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meta_Intervalo");

                entity.HasOne(d => d.Metrica)
                    .WithMany(p => p.Meta)
                    .HasForeignKey(d => d.MetricaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meta_Metrica");

                entity.HasOne(d => d.UsuarioAtualizacao)
                    .WithMany(p => p.MetaUsuarioAtualizacao)
                    .HasForeignKey(d => d.UsuarioAtualizacaoId)
                    .HasConstraintName("FK_Meta_UsuarioAtualizacao");

                entity.HasOne(d => d.UsuarioCriacao)
                    .WithMany(p => p.MetaUsuarioCriacao)
                    .HasForeignKey(d => d.UsuarioCriacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meta_UsuarioCriacao");
            });

            modelBuilder.Entity<Metrica>(entity =>
            {
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Sigla)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioAtualizacao)
                    .WithMany(p => p.MetricaUsuarioAtualizacao)
                    .HasForeignKey(d => d.UsuarioAtualizacaoId)
                    .HasConstraintName("FK_Metrica_UsuarioAtualizacao");

                entity.HasOne(d => d.UsuarioCriacao)
                    .WithMany(p => p.MetricaUsuarioCriacao)
                    .HasForeignKey(d => d.UsuarioCriacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Metrica_UsuarioCriacao");
            });

            modelBuilder.Entity<PacienteMeta>(entity =>
            {
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.DataFinal).HasColumnType("date");

                entity.Property(e => e.DataInicial).HasColumnType("date");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exercicio)
                    .WithMany(p => p.PacienteMeta)
                    .HasForeignKey(d => d.ExercicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteMeta_Exercicio");

                entity.HasOne(d => d.Fisioterapeuta)
                    .WithMany(p => p.PacienteMetaFisioterapeuta)
                    .HasForeignKey(d => d.FisioterapeutaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteMeta_Usuario");

                entity.HasOne(d => d.Intervalo)
                    .WithMany(p => p.PacienteMeta)
                    .HasForeignKey(d => d.IntervaloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteMeta_Intervalo");

                entity.HasOne(d => d.Meta)
                    .WithMany(p => p.PacienteMeta)
                    .HasForeignKey(d => d.MetaId)
                    .HasConstraintName("FK_PacienteMeta_Meta");

                entity.HasOne(d => d.Metrica)
                    .WithMany(p => p.PacienteMeta)
                    .HasForeignKey(d => d.MetricaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteMeta_Metrica");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.PacienteMeta)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteMeta_Pessoa");

                entity.HasOne(d => d.UsuarioAtualizacao)
                    .WithMany(p => p.PacienteMetaUsuarioAtualizacao)
                    .HasForeignKey(d => d.UsuarioAtualizacaoId)
                    .HasConstraintName("FK_PacienteMeta_UsuarioAtualizacao");

                entity.HasOne(d => d.UsuarioCriacao)
                    .WithMany(p => p.PacienteMetaUsuarioCriacao)
                    .HasForeignKey(d => d.UsuarioCriacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteMeta_UsuarioCriacao");
            });

            modelBuilder.Entity<PacienteMetaDiaria>(entity =>
            {
                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.PacienteMeta)
                    .WithMany(p => p.PacienteMetaDiaria)
                    .HasForeignKey(d => d.PacienteMetaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteMetaDiaria_PacienteMeta");
            });

            modelBuilder.Entity<PacienteMetaDiariaLog>(entity =>
            {
                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.PacienteMetaDiaria)
                    .WithMany(p => p.PacienteMetaDiariaLog)
                    .HasForeignKey(d => d.PacienteMetaDiariaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteMetaDiariaLog_PacienteMetaDiaria");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioAtualizacao)
                    .WithMany(p => p.PerfilUsuarioAtualizacao)
                    .HasForeignKey(d => d.UsuarioAtualizacaoId)
                    .HasConstraintName("FK_Perfil_UsuarioAtualizacao");

                entity.HasOne(d => d.UsuarioCriacao)
                    .WithMany(p => p.PerfilUsuarioCriacao)
                    .HasForeignKey(d => d.UsuarioCriacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Perfil_UsuarioCriacao");
            });

            modelBuilder.Entity<PerfilFuncao>(entity =>
            {
                entity.HasKey(e => new { e.PerfilId, e.FuncaoId });

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.HasOne(d => d.Funcao)
                    .WithMany(p => p.PerfilFuncao)
                    .HasForeignKey(d => d.FuncaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerfilFuncao_Funcao");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.PerfilFuncao)
                    .HasForeignKey(d => d.PerfilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerfilFuncao_Perfil");

                entity.HasOne(d => d.UsuarioCriacao)
                    .WithMany(p => p.PerfilFuncao)
                    .HasForeignKey(d => d.UsuarioCriacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerfilFuncao_UsuarioCriacao");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IntegracaoId)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Sobrenome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioAtualizacao)
                    .WithMany(p => p.PessoaUsuarioAtualizacao)
                    .HasForeignKey(d => d.UsuarioAtualizacaoId)
                    .HasConstraintName("FK_Pessoa_UsuarioAtualizacao");

                entity.HasOne(d => d.UsuarioCriacao)
                    .WithMany(p => p.PessoaUsuarioCriacao)
                    .HasForeignKey(d => d.UsuarioCriacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pessoa_UsuarioCriacao");
            });

            modelBuilder.Entity<Unidade>(entity =>
            {
                entity.Property(e => e.Cnes)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Unidade)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unidade_Empresa");

                entity.HasOne(d => d.UsuarioAtualizacao)
                    .WithMany(p => p.UnidadeUsuarioAtualizacao)
                    .HasForeignKey(d => d.UsuarioAtualizacaoId)
                    .HasConstraintName("FK_Unidade_UsuarioAtualizacao");

                entity.HasOne(d => d.UsuarioCriacao)
                    .WithMany(p => p.UnidadeUsuarioCriacao)
                    .HasForeignKey(d => d.UsuarioCriacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unidade_UsuarioCriacao");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Conselho)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.PessoaId)
                    .HasConstraintName("FK_Usuario_Pessoa");

                entity.HasOne(d => d.Unidade)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.UnidadeId)
                    .HasConstraintName("FK_Usuario_Unidade");
            });

            modelBuilder.Entity<UsuarioPerfil>(entity =>
            {
                entity.HasKey(e => new { e.UsuarioId, e.PerfilId });

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.UsuarioPerfil)
                    .HasForeignKey(d => d.PerfilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioPerfil_Perfil");

                entity.HasOne(d => d.UsuarioCriacao)
                    .WithMany(p => p.UsuarioPerfilUsuarioCriacao)
                    .HasForeignKey(d => d.UsuarioCriacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioPerfil_UsuarioCriacao");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioPerfilUsuario)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioPerfil_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}