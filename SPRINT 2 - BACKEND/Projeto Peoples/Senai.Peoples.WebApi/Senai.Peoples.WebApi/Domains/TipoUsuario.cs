using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class TipoUsuario
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }
    }
}
