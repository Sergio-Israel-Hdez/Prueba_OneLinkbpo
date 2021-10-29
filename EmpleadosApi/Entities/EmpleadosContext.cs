using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Entities
{
    public partial class EmpleadosContext : DbContext
    {
        public EmpleadosContext()
        {
        }

        public EmpleadosContext(DbContextOptions<EmpleadosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<SubArea> SubAreas { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Empleados;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea)
                    .HasName("PK__Area__2FC141AAD85288F0");

                entity.ToTable("Area");

                entity.Property(e => e.NombreArea)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__Empleado__CE6D8B9E036C8846");

                entity.ToTable("Empleado");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("FK__Empleado__IdArea__182C9B23");

                entity.HasOne(d => d.IdDocumentoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdDocumento)
                    .HasConstraintName("FK__Empleado__IdDocu__173876EA");
            });

            modelBuilder.Entity<SubArea>(entity =>
            {
                entity.HasKey(e => e.IdSubArea)
                    .HasName("PK__SubArea__BEDCD8EED4D8DA01");

                entity.ToTable("SubArea");

                entity.Property(e => e.NombreSubArea)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.SubAreas)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("FK__SubArea__IdArea__145C0A3F");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.IdDocumento)
                    .HasName("PK__TipoDocu__E52073476B28CA80");

                entity.ToTable("TipoDocumento");

                entity.Property(e => e.NombreDocumento)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97874D73AC");

                entity.ToTable("Usuario");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
