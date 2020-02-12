using Microsoft.EntityFrameworkCore;
using SpMedicalGroup_backend.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Infraestructure.Contexts
{
    public class SpMedGroupContext : DbContext
    {
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }
        public DbSet<StatusConsulta> StatusConsultas { get; set; }
        public DbSet<AreaSaudeEspecialidade> areaSaudeEspecialidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<ProntuarioPaciente> prontuarioPacientes{ get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        public SpMedGroupContext(DbContextOptions<SpMedGroupContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Classes mapeadoras
        }
    }
}
