using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpMedicalGroup_backend.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Infraestructure.EntityTypeConfiguration
{
    public class AreaSaudeEspecialidadeEntityTypeConfiguration : IEntityTypeConfiguration<AreaSaudeEspecialidade>
    {
        public void Configure(EntityTypeBuilder<AreaSaudeEspecialidade> builder)
        {
            builder.ToTable("AreasSaudeEspecialidades");

            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo).IsRequired();
            builder.HasIndex(x => x.Titulo)
                .IsUnique();
        }
    }
}
