using Senai.InLock.WebApi.DatabaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DatabaseFirst.Interfaces
{
    public interface IEstudioRepository
    {
        Estudios Create(Estudios estudio);
        List<Estudios> GetAll();
        Estudios GetbyId(int id);
    }
}
