using SpMedicalGroup_backend.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Domains
{
    public class Consulta : AbstractDomain
    {
        public DateTime DataHoraConsulta { get; set; }
        public string Descricao { get; set; }
        public long MedicoId { get; set; }
        public long ProntuarioPacienteId { get; set; }
        public long StatusConsultaId { get; set; }

        public Consulta()
        {

        }
    }
}
