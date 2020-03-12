using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GufisBD.Models.Domain
{
    public class Presenca
    {
        public int Id { get; set; }
        public string Situacao { get; set; }
        public int EventoId { get; set; }
        public int UsuarioId { get; set; }
    }
}
