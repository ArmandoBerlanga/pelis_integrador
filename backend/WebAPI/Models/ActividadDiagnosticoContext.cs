using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPI.Models
{
    public partial class ActividadDiagnosticoContext : DbContext
    {
        public ActividadDiagnosticoContext()
        {
        }

        public ActividadDiagnosticoContext(DbContextOptions<ActividadDiagnosticoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<PeliculaId> PeliculaIds { get; set; }
        public virtual DbSet<PeliculaProtagonistum> PeliculaProtagonista { get; set; }
        public virtual DbSet<Protagonistum> Protagonista { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ActividadDiagnostico;User=sa;Password=Pass123*;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK__Categori__F353C1C50206CC31");

                entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");

                entity.Property(e => e.DescripcionCorta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionLarga)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("Director");

                entity.Property(e => e.DirectorId).HasColumnName("DirectorID");

                entity.Property(e => e.NombreDirector)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PeliculaId>(entity =>
            {
                entity.HasKey(e => e.PeliculaId1)
                    .HasName("PK__Pelicula__5AC6F32CA7C7FA8E");

                entity.ToTable("PeliculaID");

                entity.Property(e => e.PeliculaId1).HasColumnName("PeliculaID");

                entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");

                entity.Property(e => e.Duracion).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NombrePelicula)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.PeliculaIds)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK__PeliculaI__Categ__29572725");
            });

            modelBuilder.Entity<PeliculaProtagonistum>(entity =>
            {
                entity.HasKey(e => new { e.PeliculaId, e.ProtagonistaId })
                    .HasName("PK_PeliProta");

                entity.Property(e => e.PeliculaId).HasColumnName("PeliculaID");

                entity.Property(e => e.ProtagonistaId).HasColumnName("ProtagonistaID");

                entity.HasOne(d => d.Pelicula)
                    .WithMany(p => p.PeliculaProtagonista)
                    .HasForeignKey(d => d.PeliculaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PeliculaP__Pelic__2E1BDC42");

                entity.HasOne(d => d.Protagonista)
                    .WithMany(p => p.PeliculaProtagonista)
                    .HasForeignKey(d => d.ProtagonistaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PeliculaP__Prota__2F10007B");
            });

            modelBuilder.Entity<Protagonistum>(entity =>
            {
                entity.HasKey(e => e.ProtagonistaId)
                    .HasName("PK__Protagon__A3227ECCF1B82FDC");

                entity.Property(e => e.ProtagonistaId).HasColumnName("ProtagonistaID");

                entity.Property(e => e.NombreProtagonista)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
