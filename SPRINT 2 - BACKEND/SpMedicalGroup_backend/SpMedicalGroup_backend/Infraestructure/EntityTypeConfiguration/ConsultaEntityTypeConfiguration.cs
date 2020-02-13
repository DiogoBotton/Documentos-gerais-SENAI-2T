using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpMedicalGroup_backend.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Infraestructure.EntityTypeConfiguration
{
    public class ConsultaEntityTypeConfiguration : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("Consultas");

            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);

            builder.HasOne<Medico>()
                .WithMany()
                .HasForeignKey("MedicoId")
                .IsRequired();

            builder.HasOne<StatusConsulta>()
                 .WithMany()
                 .HasForeignKey("StatusConsultaId")
                 .IsRequired();

            builder.HasOne<ProntuarioPaciente>()
                .WithMany()
                .HasForeignKey("ProntuarioPacienteId")
                .IsRequired();
        }
    }
}
