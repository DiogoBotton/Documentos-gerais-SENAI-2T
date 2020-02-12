using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Domains
{
    public class ProntuarioPaciente
    {
        public int Id { get; set; }
        public string RG { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public int UsuarioId { get; set; }

        public ProntuarioPaciente()
        {

        }
    }
}
