using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    public interface IUsuario
    {
        Usuario BuscarPorNomeEmail(Usuario usuario);
    }
}
