using GufisBD.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GufisBD.Repositories.EntityTypesConfiguration
{
    public class UsuarioEntityTypeConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);

            builder.HasOne<TipoUsuario>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("TipoUsuarioId");
        }
    }
}
