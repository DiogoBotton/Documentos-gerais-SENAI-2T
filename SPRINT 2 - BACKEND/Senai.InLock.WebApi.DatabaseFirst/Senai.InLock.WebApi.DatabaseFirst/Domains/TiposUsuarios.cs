using System;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.DatabaseFirst.Domains
{
    public partial class TiposUsuarios
    {
        public TiposUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
