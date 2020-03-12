using Senai.Gufi.WebApi.Contexts;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        public GufiContext ctx;

        public PresencaRepository()
        {
            ctx = new GufiContext();
        }

        public Presenca Create(Presenca presenca)
        {
            return ctx.Presenca.Add(presenca).Entity;
        }
    }
}
