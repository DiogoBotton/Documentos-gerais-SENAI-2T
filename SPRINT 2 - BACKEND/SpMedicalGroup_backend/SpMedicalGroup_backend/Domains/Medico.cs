using SpMedicalGroup_backend.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Domains
{
    public class Medico : AbstractDomain
    {
        public string CRM { get; set; }
        public long UsuarioId { get; set; }
        public long AreaSaudeEspecialidadeId { get; set; }
        public long ClinicaId { get; set; }

        public Medico()
        {

        }
    }
}
