using Microsoft.EntityFrameworkCore;
using SpMedicalGroup_backend.Domains;
using SpMedicalGroup_backend.Infraestructure.EntityTypeConfiguration;
using SpMedicalGroup_backend.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Infraestructure.Contexts
{
    public class SpMedGroupContext : DbContext, IUnitOfWork
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

            //Caso houver uma referencia de 2 Foreign Key's para uma mesma tabela, o loop altera o comportamento de Cascata para Restrito
            //[...] automaticamente ao fazer a migration
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

        }

        //Padrão de repositorios usando UnitOfWork, salva alterações na DB independentemente de quais tabelas foram alteradas.
        public async Task SaveDbChanges(CancellationToken cancellationToken = default)
        {
            await base.SaveChangesAsync();
        }
    }
}
