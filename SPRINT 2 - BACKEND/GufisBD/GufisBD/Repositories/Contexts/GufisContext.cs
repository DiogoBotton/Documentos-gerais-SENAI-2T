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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
