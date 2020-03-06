using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.InLock.Manha.Domains
{
    public partial class InLockContext : DbContext
    {
        public InLockContext()
        {
        }

        public InLockContext(DbContextOptions<InLockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEstudios> TblEstudios { get; set; }
        public virtual DbSet<TblJogos> TblJogos { get; set; }
        public virtual DbSet<TblTiposUsuario> TblTiposUsuario { get; set; }
        public virtual DbSet<TblUsuarios> TblUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DEV6\\SQLEXPRESS; Initial Catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEstudios>(entity =>
            {
                entity.HasKey(e => e.IdEstudio);

                entity.ToTable("TBL_ESTUDIOS");

                entity.HasIndex(e => e.NomeEstudio)
                    .HasName("UQ__TBL_ESTU__85DF8EB7C6DE7640")
                    .IsUnique();

                entity.Property(e => e.IdEstudio).HasColumnName("ID_ESTUDIO");

                entity.Property(e => e.NomeEstudio)
                    .IsRequired()
                    .HasColumnName("NOME_ESTUDIO")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblJogos>(entity =>
            {
                entity.HasKey(e => e.IdJogo);

                entity.ToTable("TBL_JOGOS");

                entity.Property(e => e.IdJogo).HasColumnName("ID_JOGO");

                entity.Property(e => e.DataLancamento)
                    .HasColumnName("DATA_LANCAMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstudio).HasColumnName("ID_ESTUDIO");

                entity.Property(e => e.NomeJogo)
                    .IsRequired()
                    .HasColumnName("NOME_JOGO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnName("VALOR");

                entity.HasOne(d => d.IdEstudioNavigation)
                    .WithMany(p => p.TblJogos)
                    .HasForeignKey(d => d.IdEstudio)
                    .HasConstraintName("FK__TBL_JOGOS__ID_ES__3A81B327");
            });

            modelBuilder.Entity<TblTiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.ToTable("TBL_TiposUsuario");

                entity.HasIndex(e => e.NomeTipo)
                    .HasName("UQ__TBL_Tipo__2B206E03EDCC9795")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario)
                    .HasColumnName("ID_TipoUsuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.NomeTipo)
                    .IsRequired()
                    .HasColumnName("NOME_TIPO")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("TBL_USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__TBL_USUA__161CF72474EE2F3C")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Apelido)
                    .IsRequired()
                    .HasColumnName("APELIDO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__TBL_USUAR__ID_Ti__412EB0B6");
            });
        }
    }
}
