using System;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.DatabaseFirst.Domains
{
    public partial class Estudios
    {
        public Estudios()
        {
            Jogos = new HashSet<Jogos>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Jogos> Jogos { get; set; }
    }
}
