using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.InLock.WebApi.DatabaseFirst.Domains
{
    public partial class InLockContext : DbContext
    {
        //Linha de comando para mapear o banco de dados
        /* Scaffold-DbContext "Data Source=DEV1\SQLEXPRESS; initial catalog=InLock_Tarde; User Id=sa;Password=sa@132" 
         * Microsoft.EntityFrameworkCore.SqlServer 
         * -OutputDir Domains 
         * -ContextDir Contexts 
         * -Context InLockContext
         */
        public InLockContext()
        {
        }

        public InLockContext(DbContextOptions<InLockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudios> Estudios { get; set; }
        public virtual DbSet<Jogos> Jogos { get; set; }
        public virtual DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DEV1\\SQLEXPRESS; initial catalog=InLock_Tarde; User Id=sa;Password=sa@132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudios>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jogos>(entity =>
            {
                entity.Property(e => e.DataLancamento).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("money");

                entity.HasOne(d => d.Estudio)
                    .WithMany(p => p.Jogos)
                    .HasForeignKey(d => d.EstudioId)
                    .HasConstraintName("FK__Jogos__EstudioId__3B75D760");
            });

            modelBuilder.Entity<TiposUsuarios>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoUsuario)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuarioId)
                    .HasConstraintName("FK__Usuarios__TipoUs__3E52440B");
            });
        }
    }
}
