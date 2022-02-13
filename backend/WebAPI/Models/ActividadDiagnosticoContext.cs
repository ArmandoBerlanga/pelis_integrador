using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace WebAPI.Models
{
    public partial class ActividadDiagnosticoContext : DbContext
    {
        private IConfiguration _configuration { get; }

        public ActividadDiagnosticoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActividadDiagnosticoContext(DbContextOptions<ActividadDiagnosticoContext> options, IConfiguration configuration): base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Director> Director { get; set; }
        public virtual DbSet<Protagonista> Protagonista { get; set; }
        public virtual DbSet<Pelicula> ListaPelicula { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)       
                optionsBuilder.UseSqlServer( _configuration.GetSection("ConnectionStrings")["Dev"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK__Categori__F353C1C59A212FBF");

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

            modelBuilder.Entity<Protagonista>(entity =>
            {
                entity.HasKey(e => e.ProtagonistaId)
                    .HasName("PK__Protagon__A3227ECC6135A636");

                entity.Property(e => e.ProtagonistaId).HasColumnName("ProtagonistaID");

                entity.Property(e => e.NombreProtagonista)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("Pelicula");

                entity.Property(e => e.PeliculaId).HasColumnName("PeliculaID");

                entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");

                entity.Property(e => e.Duracion).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NombrePelicula)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionCorta)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Poster).IsUnicode(false);

                entity.Property(e => e.NombreDirector)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
