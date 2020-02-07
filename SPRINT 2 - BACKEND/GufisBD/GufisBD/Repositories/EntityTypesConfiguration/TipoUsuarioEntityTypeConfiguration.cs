using GufisBD.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GufisBD.Repositories.EntityTypesConfiguration
{
    public class TipoUsuarioEntityTypeConfiguration : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.ToTable("TiposUsuarios");
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
        }
    }
}
