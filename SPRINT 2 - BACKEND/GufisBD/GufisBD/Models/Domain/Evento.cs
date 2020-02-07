using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GufisBD.Models.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string NomeEvento { get; set; }
        public DateTime DataDoEvento { get; set; }
        public bool Acesso { get; set; }
        public string Descricao { get; set; }
        public int InstituicaoId { get; set; }
        public int TipoEventoId { get; set; }
    }
}
