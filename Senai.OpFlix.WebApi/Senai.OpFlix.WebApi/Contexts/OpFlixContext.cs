using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class OpFlixContext : DbContext
    {
        public OpFlixContext()
        {
        }

        public OpFlixContext(DbContextOptions<OpFlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Plataformas> Plataformas { get; set; }
        public virtual DbSet<TiposTitulos> TiposTitulos { get; set; }
        public virtual DbSet<Titulos> Titulos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        // Unable to generate entity type for table 'dbo.Favoritos'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=M_OpFlix;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Favoritos>()
                .HasKey(bc => new { bc.IdUsuario, bc.IdTitulo});
            modelBuilder.Entity<Favoritos>()
                .HasOne(bc => bc.Usuario)
                .WithMany(b => b.Favoritos)
                .HasForeignKey(bc => bc.IdUsuario);
            modelBuilder.Entity<Favoritos>()
                .HasOne(bc => bc.Titulo)
                .WithMany(c => c.Favoritos)
                .HasForeignKey(bc => bc.IdTitulo);



            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Plataformas>(entity =>
            {
                entity.HasKey(e => e.IdPlataforma);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposTitulos>(entity =>
            {
                entity.HasKey(e => e.IdTipoTitulo);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Titulos>(entity =>
            {
                entity.HasKey(e => e.IdTitulo);

                entity.Property(e => e.Classificacao)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataLancamento).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopse).HasColumnType("text");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Titulos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Titulos__IdCateg__5441852A");

                entity.HasOne(d => d.IdPlataformaNavigation)
                    .WithMany(p => p.Titulos)
                    .HasForeignKey(d => d.IdPlataforma)
                    .HasConstraintName("FK__Titulos__IdPlata__534D60F1");

                entity.HasOne(d => d.IdTipoTituloNavigation)
                    .WithMany(p => p.Titulos)
                    .HasForeignKey(d => d.IdTipoTitulo)
                    .HasConstraintName("FK__Titulos__IdTipoT__5535A963");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D105344B3BCB62")
                    .IsUnique();

                entity.Property(e => e.Admin).HasDefaultValueSql("('FALSE')");

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Imagem).IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
