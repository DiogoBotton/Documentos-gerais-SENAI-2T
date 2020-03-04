using System;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.DatabaseFirst.Domains
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? TipoUsuarioId { get; set; }

        public TiposUsuarios TipoUsuario { get; set; }
    }
}
