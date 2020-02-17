using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SpMedicalGroup_backend.Infraestructure.Contexts;
using SpMedicalGroup_backend.Helpers;
using SpMedicalGroup_backend.Infraestructure.Repositories;
using SpMedicalGroup_backend.Interfaces;

namespace SpMedicalGroup_backend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //DependencyInjecions(DI) Vinculando a dependencia da classe repository com a InterfaceRepository
            //Em outras palavras, você pode usar a implementação dos métodos do repository, apenas instanciando... A interface! loucura neh? Foi o que eu pensei também!
            services.AddScoped<IStatusConsultaRepository, StatusConsultaRepository>();
            services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //**
            //Configurações da DB
            //**
            services.AddDbContext<SpMedGroupContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime, IServiceScopeFactory services)
        {
            //Método que aplica jobs sempre que a API é inicializada. (registra o serviço na inicialização)
            applicationLifetime.ApplicationStarted.Register(() =>
            {
                app.ConfigureJobsAsync();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
