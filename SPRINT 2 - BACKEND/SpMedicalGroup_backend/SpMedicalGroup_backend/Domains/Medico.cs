using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Domains
{
    public class Medico
    {
        public int Id { get; set; }
        public string CRM { get; set; }
        public int UsuarioId { get; set; }
        public int AreaSaudeEspecialidadeId { get; set; }
        public int ClinicaId { get; set; }

        public Medico()
        {

        }
    }
}
