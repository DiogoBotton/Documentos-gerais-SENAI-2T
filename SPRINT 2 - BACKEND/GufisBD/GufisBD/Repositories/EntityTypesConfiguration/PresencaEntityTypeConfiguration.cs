using GufisBD.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GufisBD.Repositories.EntityTypesConfiguration
{
    public class PresencaEntityTypeConfiguration : IEntityTypeConfiguration<Presenca>
    {
        public void Configure(EntityTypeBuilder<Presenca> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);

            builder.HasOne<Evento>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("EventoId");

            builder.HasOne<Usuario>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("UsuarioId");
        }
    }
}
