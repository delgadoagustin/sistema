using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Sistema.laboratorio
{
    public partial class laboratorioContext : DbContext
    {
        readonly string connectionString;

        public laboratorioContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public laboratorioContext(DbContextOptions<laboratorioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>(entity =>
            {
                entity.ToTable("medicos");

                entity.Property(e => e.MedicoId).HasColumnName("medicoId");

                entity.Property(e => e.MedicoMatricula)
                    .HasMaxLength(12)
                    .HasColumnName("medicoMatricula");

                entity.Property(e => e.MedicoNombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("medicoNombre");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("pacientes");

                entity.Property(e => e.PacienteId).HasColumnName("pacienteId");

                entity.Property(e => e.PacienteDni)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("pacienteDni");

                entity.Property(e => e.PacienteEmail)
                    .HasMaxLength(60)
                    .HasColumnName("pacienteEmail");

                entity.Property(e => e.PacienteFechaNac)
                    .HasColumnType("date")
                    .HasColumnName("pacienteFechaNac");

                entity.Property(e => e.PacienteNombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("pacienteNombre");

                entity.Property(e => e.PacienteSexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("pacienteSexo");

                entity.Property(e => e.PacienteTelefono)
                    .HasMaxLength(15)
                    .HasColumnName("pacienteTelefono");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");

                entity.Property(e => e.UsuarioNivel)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("usuarioNivel")
                    .IsFixedLength(true);

                entity.Property(e => e.UsuarioNombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("usuarioNombre");

                entity.Property(e => e.UsuarioPass)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("usuarioPass");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
