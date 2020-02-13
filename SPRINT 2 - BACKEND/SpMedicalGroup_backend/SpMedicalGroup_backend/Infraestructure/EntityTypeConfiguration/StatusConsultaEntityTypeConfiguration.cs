using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpMedicalGroup_backend.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Infraestructure.EntityTypeConfiguration
{
    public class StatusConsultaEntityTypeConfiguration : IEntityTypeConfiguration<StatusConsulta>
    {
        public void Configure(EntityTypeBuilder<StatusConsulta> builder)
        {
            builder.ToTable("StatusConsultas");

            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo).IsRequired();
            builder.HasIndex(x => x.Titulo)
                .IsUnique();
        }
    }
}
