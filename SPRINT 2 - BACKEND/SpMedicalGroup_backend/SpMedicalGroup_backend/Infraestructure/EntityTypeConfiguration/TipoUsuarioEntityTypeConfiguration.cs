using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpMedicalGroup_backend.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Infraestructure.EntityTypeConfiguration
{
    public class TipoUsuarioEntityTypeConfiguration : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Titulo)
                .IsUnique();
        }
    }
}
