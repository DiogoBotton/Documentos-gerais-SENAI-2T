using Microsoft.EntityFrameworkCore;
using SpMedicalGroup_backend.Domains;
using SpMedicalGroup_backend.Infraestructure.EntityTypeConfiguration;
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
        public DbSet<AreaSaudeEspecialidade> AreasSaudeEspecialidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<ProntuarioPaciente> ProntuariosPacientes{ get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        public SpMedGroupContext(DbContextOptions<SpMedGroupContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Classes mapeadoras
            modelBuilder.ApplyConfiguration(new ClinicaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ConsultaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MedicoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TipoUsuarioEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProntuarioPacienteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AreaSaudeEspecialidadeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConsultaEntityTypeConfiguration());
        }
    }
}
