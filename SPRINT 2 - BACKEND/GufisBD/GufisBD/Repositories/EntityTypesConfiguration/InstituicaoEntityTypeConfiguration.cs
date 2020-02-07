using GufisBD.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GufisBD.Repositories.EntityTypesConfiguration
{
    public class InstituicaoEntityTypeConfiguration : IEntityTypeConfiguration<Instituicao>
    {
        public void Configure(EntityTypeBuilder<Instituicao> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);
        }
    }
}
