using GufisBD.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GufisBD.Repositories.EntityTypesConfiguration
{
    public class TipoEventoEntityTypeConfiguration : IEntityTypeConfiguration<TipoEvento>
    {
        public void Configure(EntityTypeBuilder<TipoEvento> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
        }
    }
}
