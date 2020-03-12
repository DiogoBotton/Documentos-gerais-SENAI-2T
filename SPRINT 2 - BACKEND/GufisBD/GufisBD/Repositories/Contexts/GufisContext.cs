using GufisBD.Models.Domain;
using GufisBD.Repositories.EntityTypesConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GufisBD.Repositories.Contexts
{
    public class GufisContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<TipoEvento> TipoEventos { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Presenca> Presencas { get; set; }

        public GufisContext(DbContextOptions<GufisContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DEV1\\SQLEXPRESS; initial catalog=Senatur_Tarde; user Id=sa; pwd=sa@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Classes mapeadoras EntityTypeConfiguration
            modelBuilder.ApplyConfiguration(new TipoUsuarioEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TipoEventoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InstituicaoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EventoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PresencaEntityTypeConfiguration());
        }
    }
}
