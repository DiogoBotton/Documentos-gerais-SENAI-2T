using Senai.InLock.WebApi.DatabaseFirst.Domains;
using Senai.InLock.WebApi.DatabaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DatabaseFirst.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        InLockContext ctx = new InLockContext();

        public List<Jogos> GetAll()
        {
            return ctx.Jogos.ToList();
        }

        public Jogos GetById(int id)
        {
            return ctx.Jogos.FirstOrDefault(x => x.Id == id);
        }

        public void UpdatePath(Jogos jogo)
        {
            ctx.Jogos.Update(jogo);
            ctx.SaveChanges();
        }
    }
}
