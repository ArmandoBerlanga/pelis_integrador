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

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<PeliculaProtagonistum> PeliculaProtagonista { get; set; }
        public virtual DbSet<PosterPelicula> PosterPeliculas { get; set; }
        public virtual DbSet<Protagonistum> Protagonista { get; set; }
        public virtual DbSet<PeliculaCompleta> ListaPeliculas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)       
                optionsBuilder.UseSqlServer( _configuration.GetSection("ConnectionStrings")["Dev"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
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

            modelBuilder.Entity<PeliculaProtagonistum>(entity =>
            {
                entity.HasKey(e => new { e.PeliculaId, e.ProtagonistaId })
                    .HasName("PK_PeliProta");

                entity.Property(e => e.PeliculaId).HasColumnName("PeliculaID");

                entity.Property(e => e.ProtagonistaId).HasColumnName("ProtagonistaID");

            });

            modelBuilder.Entity<PosterPelicula>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PosterPelicula");

                entity.Property(e => e.PeliculaId).HasColumnName("PeliculaID");

                entity.Property(e => e.Poster).IsUnicode(false);

            });

            modelBuilder.Entity<Protagonistum>(entity =>
            {
                entity.HasKey(e => e.ProtagonistaId)
                    .HasName("PK__Protagon__A3227ECC6135A636");

                entity.Property(e => e.ProtagonistaId).HasColumnName("ProtagonistaID");

                entity.Property(e => e.NombreProtagonista)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PeliculaCompleta>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("PeliculaCompleta");

                entity.Property(e => e.PeliculaId).HasColumnName("PeliculaID");

                entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");

                entity.Property(e => e.Duracion).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NombrePelicula)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionCorta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionLarga)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
