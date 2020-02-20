using Microsoft.EntityFrameworkCore;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Context
{
    public class PeoplesContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }

        public PeoplesContext(DbContextOptions<PeoplesContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioEntityTypeConfiguration());
        }
    }
}
