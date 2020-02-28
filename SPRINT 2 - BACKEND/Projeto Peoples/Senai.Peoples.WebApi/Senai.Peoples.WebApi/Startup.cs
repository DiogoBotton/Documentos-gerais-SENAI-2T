using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Senai.Peoples.WebApi.Context;

namespace Senai.Peoples.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //// Padrão
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Configurações da DB
            services.AddDbContext<PeoplesContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //*
            //Configurando o JWT (Autentificação)
            //*
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //Verificando...

                    //Quem esta solicitando
                    ValidateIssuer = true,

                    //Quem esta recebendo
                    ValidateAudience = true,

                    //Valida o tempo de expiração do token
                    ValidateLifetime = true,

                    //Forma da criptografia
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("peoples-chave-autenticacao")),

                    //Tempo de expiração do token
                    ClockSkew = TimeSpan.FromMinutes(30),

                    // Nome da issuer, de onde está vindo
                    ValidIssuer = "Filmes.WebApi",

                    // Nome da audience, de onde está vindo
                    ValidAudience = "Filmes.WebApi"
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Habilita o uso de autenticação
            app.UseAuthentication();

            // Habilita o uso de mvc
            app.UseMvc();
        }
    }
}
