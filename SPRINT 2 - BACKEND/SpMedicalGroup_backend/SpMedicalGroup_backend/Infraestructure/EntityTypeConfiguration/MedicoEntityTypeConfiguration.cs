using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpMedicalGroup_backend.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Infraestructure.EntityTypeConfiguration
{
    public class MedicoEntityTypeConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medicos");

            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CRM).IsRequired();

            builder.HasOne<Usuario>()
                .WithMany()
                .HasForeignKey("UsuarioId")
                .IsRequired();

            builder.HasOne<Clinica>()
                .WithMany()
                .HasForeignKey("ClinicaId")
                .IsRequired();

            builder.HasOne<AreaSaudeEspecialidade>()
                .WithMany()
                .HasForeignKey("AreaSaudeEspecialidadeId")
                .IsRequired();
        }
    }
}
