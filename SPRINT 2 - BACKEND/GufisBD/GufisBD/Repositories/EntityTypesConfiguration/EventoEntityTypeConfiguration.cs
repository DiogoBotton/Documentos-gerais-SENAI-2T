using GufisBD.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GufisBD.Repositories.EntityTypesConfiguration
{
    public class EventoEntityTypeConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.HasOne<Instituicao>()
                .WithMany()
                .HasForeignKey("InstituicaoId")
                .IsRequired();

            builder.HasOne<TipoEvento>()
                .WithMany()
                .HasForeignKey("TipoEventoId")
                .IsRequired();

        }
    }
}
