using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpMedicalGroup_backend.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Infraestructure.EntityTypeConfiguration
{
    public class ProntuarioPacienteEntityTypeConfiguration : IEntityTypeConfiguration<ProntuarioPaciente>
    {
        public void Configure(EntityTypeBuilder<ProntuarioPaciente> builder)
        {
            builder.ToTable("ProntuariosPacientes");

            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RG).IsRequired();
            builder.HasIndex(x => x.RG)
                .IsUnique();

            builder.HasOne<Usuario>()
                .WithMany()
                .HasForeignKey("UsuarioId")
                .IsRequired();
        }
    }
}
