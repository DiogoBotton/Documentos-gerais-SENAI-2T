using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpMedicalGroup_backend.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Infraestructure.EntityTypeConfiguration
{
    public class UsuarioEntityTypeConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.Senha).IsRequired();
            builder.Property(x => x.Nome).IsRequired();

            builder.HasOne<TipoUsuario>()
                .WithMany()
                .HasForeignKey("TipoUsuarioId")
                .IsRequired();
        }
    }
}
