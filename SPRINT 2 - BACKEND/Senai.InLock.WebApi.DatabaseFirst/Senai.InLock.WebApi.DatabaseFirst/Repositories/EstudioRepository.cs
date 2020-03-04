using Senai.InLock.WebApi.DatabaseFirst.Domains;
using Senai.InLock.WebApi.DatabaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DatabaseFirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();

        public Estudios Create(Estudios estudio)
        {
            var retorno = ctx.Estudios.Add(estudio).Entity;
            ctx.SaveChanges();
            return retorno;
        }

        public List<Estudios> GetAll()
        {
            return ctx.Estudios.ToList();
        }

        public Estudios GetbyId(int id)
        {
            return ctx.Estudios.FirstOrDefault(x => x.Id == id);
        }
    }
}
