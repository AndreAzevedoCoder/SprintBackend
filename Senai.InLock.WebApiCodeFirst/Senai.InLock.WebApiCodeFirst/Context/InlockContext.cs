using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApiCodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApiCodeFirst.Context
{
    public class InlockContext : DbContext
    {
        public DbSet<TipoUsuario> tiposUsuarios { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Estudio> estudio { get; set; }
        public DbSet<Jogos> jogos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DEV6\\SQLEXPRESS; Database=Inlock_Games_CodeFirst_Manha; user Id=sa; pwd=sa@132;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoUsuario>().HasData(
                    new TipoUsuario
                    {
                        idTipoUsuario = 1,
                        titulo = "Administrador"
                    },
                    new TipoUsuario
                    {
                        idTipoUsuario = 2,
                        titulo = "Usuario"
                    }
                    );

            modelBuilder.Entity<Estudio>().HasData(
                    new Estudio { idEstudio = 1, nomeEstudio = "Blizzard" },
                    new Estudio { idEstudio = 1, nomeEstudio = "Rockstar Studios" },
                    new Estudio { idEstudio = 1, nomeEstudio = "Square Enix" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
