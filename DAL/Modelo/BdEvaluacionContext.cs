using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Modelo;

//contexto de nuestra bd con su correspondiente dbcontext y dbset
public partial class BdEvaluacionContext : DbContext
{
    public BdEvaluacionContext()
    {
    }

    public BdEvaluacionContext(DbContextOptions<BdEvaluacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EvaCatEvaluacion> EvaCatEvaluacions { get; set; }

    public virtual DbSet<EvaTchNotasEvaluación> EvaTchNotasEvaluacións { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=bd_evaluacion;User Id=postgres;Password=AlumnoCMI2");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EvaCatEvaluacion>(entity =>
        {
            entity.HasKey(e => e.CodEvaluacion).HasName("eva_cat_evaluacion_pkey");

            entity.ToTable("eva_cat_evaluacion", "sc_evaluacion");

            entity.Property(e => e.CodEvaluacion)
                .HasColumnType("character varying")
                .HasColumnName("cod_evaluacion");
            entity.Property(e => e.DescEvaluacion)
                .HasColumnType("character varying")
                .HasColumnName("desc_evaluacion");
        });

        modelBuilder.Entity<EvaTchNotasEvaluación>(entity =>
        {
            entity.HasKey(e => e.IdNotaEvaluacion).HasName("eva_tch_notas_evaluación_pkey");

            entity.ToTable("eva_tch_notas_evaluación", "sc_evaluacion");

            entity.Property(e => e.IdNotaEvaluacion).HasColumnName("id_nota_evaluacion");
            entity.Property(e => e.CodAlumno)
                .HasColumnType("character varying")
                .HasColumnName("cod_alumno");
            entity.Property(e => e.CodEvaluacion)
                .HasColumnType("character varying")
                .HasColumnName("cod_evaluacion");
            entity.Property(e => e.MdFch)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_fch");
            entity.Property(e => e.MdUuid)
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
            entity.Property(e => e.NotaEvaluacion).HasColumnName("nota_evaluacion");

            entity.HasOne(d => d.CodEvaluacionNavigation).WithMany(p => p.EvaTchNotasEvaluacións)
                .HasForeignKey(d => d.CodEvaluacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("eva_tch_notas_evaluación_cod_evaluacion_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
