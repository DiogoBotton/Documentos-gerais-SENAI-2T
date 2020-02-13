using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Domains
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime DataHoraConsulta { get; set; }
        public string Descricao { get; set; }
        public int MedicoId { get; set; }
        public int ProntuarioPacienteId { get; set; }
        public int StatusConsultaId { get; set; }

        public Consulta()
        {

        }
    }
}
