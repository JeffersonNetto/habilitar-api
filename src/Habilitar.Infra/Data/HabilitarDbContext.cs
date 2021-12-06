﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Habilitar.Core.Models;

#nullable disable

namespace Habilitar.Infra.Data
{
    public partial class HabilitarDbContext : DbContext
    {
        public HabilitarDbContext()
        {
        }

        public HabilitarDbContext(DbContextOptions<HabilitarDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Exercicio> Exercicio { get; set; }
        public virtual DbSet<ExercicioGrupo> ExercicioGrupo { get; set; }
        public virtual DbSet<ExercicioMetrica> ExercicioMetrica { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Intervalo> Intervalo { get; set; }
        public virtual DbSet<LogAcesso> LogAcesso { get; set; }
        public virtual DbSet<LogErro> LogErro { get; set; }
        public virtual DbSet<Meta> Meta { get; set; }
        public virtual DbSet<Metrica> Metrica { get; set; }
        public virtual DbSet<PacienteMeta> PacienteMeta { get; set; }
        public virtual DbSet<PacienteMetaDiaria> PacienteMetaDiaria { get; set; }
        public virtual DbSet<PacienteMetaDiariaLog> PacienteMetaDiariaLog { get; set; }
        public virtual DbSet<Unidade> Unidade { get; set; }

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
            });

            modelBuilder.Entity<ExercicioGrupo>(entity =>
            {
                entity.HasKey(e => new { e.ExercicioId, e.GrupoId });

                entity.HasIndex(e => e.GrupoId, "IX_ExercicioGrupo_GrupoId");

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
            });

            modelBuilder.Entity<ExercicioMetrica>(entity =>
            {
                entity.HasKey(e => new { e.ExercicioId, e.MetricaId });

                entity.HasIndex(e => e.MetricaId, "IX_ExercicioMetrica_MetricaId");

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
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao)
                    .HasMaxLength(200)
                    .IsUnicode(false);
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
            });

            modelBuilder.Entity<Meta>(entity =>
            {                
                entity.HasIndex(e => e.ExercicioId, "IX_Meta_ExercicioId");

                entity.HasIndex(e => e.IntervaloId, "IX_Meta_IntervaloId");

                entity.HasIndex(e => e.MetricaId, "IX_Meta_MetricaId");

                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exercicio)
                    .WithMany(p => p.Meta)
                    .HasForeignKey(d => d.ExercicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meta_Exercicio");

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
            });

            modelBuilder.Entity<PacienteMeta>(entity =>
            {
                entity.HasIndex(e => e.ExercicioId, "IX_PacienteMeta_ExercicioId");

                entity.HasIndex(e => e.IntervaloId, "IX_PacienteMeta_IntervaloId");

                entity.HasIndex(e => e.MetaId, "IX_PacienteMeta_MetaId");

                entity.HasIndex(e => e.MetricaId, "IX_PacienteMeta_MetricaId");

                entity.HasIndex(e => e.UserId, "IX_PacienteMeta_UserId");

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

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PacienteMeta)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteMeta_User");
            });

            modelBuilder.Entity<PacienteMetaDiaria>(entity =>
            {
                entity.HasIndex(e => e.PacienteMetaId, "IX_PacienteMetaDiaria_PacienteMetaId");

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
                entity.HasIndex(e => e.PacienteMetaDiariaId, "IX_PacienteMetaDiariaLog_PacienteMetaDiariaId");

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

            modelBuilder.Entity<Unidade>(entity =>
            {
                entity.HasIndex(e => e.EmpresaId, "IX_Unidade_EmpresaId");

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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}