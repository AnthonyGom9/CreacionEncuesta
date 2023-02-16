using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CreacionEncuesta.Models;

public partial class DataBaseAcmeContext : DbContext
{
    public DataBaseAcmeContext()
    {
    }

    public DataBaseAcmeContext(DbContextOptions<DataBaseAcmeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetalleEncuestum> DetalleEncuesta { get; set; }

    public virtual DbSet<Encuestum> Encuesta { get; set; }

    public virtual DbSet<RespuestaEncuestum> RespuestaEncuesta { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\DISAGRO;Database=DataBaseAcme; Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleEncuestum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Detalle___3213E83F8A845281");

            entity.ToTable("Detalle_Encuesta");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EstadoRegistro).HasColumnName("Estado_Registro");
            entity.Property(e => e.IdDetalle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_Detalle");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Resultado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Encuestum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Encuesta__3213E83F449B5F3E");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DetalleEncuesta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("detalle_encuesta");
            entity.Property(e => e.EstadoRegistro).HasColumnName("Estado_Registro");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioRegistro).HasColumnName("Usuario_registro");
        });

        modelBuilder.Entity<RespuestaEncuestum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Respuest__3213E83F3855008D");

            entity.ToTable("Respuesta_Encuesta");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDetalleEncuesta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_Detalle_Encuesta");
            entity.Property(e => e.IdResultaEncuesta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Id_resulta_encuesta");
            entity.Property(e => e.NombrePerson)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_person");
            entity.Property(e => e.Respuesta)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("respuesta");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuarios__3213E83F62295672");

            entity.ToTable("usuarios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
