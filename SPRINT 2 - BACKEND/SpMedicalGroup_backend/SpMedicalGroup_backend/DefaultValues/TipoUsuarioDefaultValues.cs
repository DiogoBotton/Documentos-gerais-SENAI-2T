using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.DefaultValues
{
    public class TipoUsuarioDefaultValuesAcess
    {
        public static string GetValue(TipoUsuarioDefaultValues tipoUsuarioDefaultValues)
        {
            string retorno = null;
            switch (tipoUsuarioDefaultValues)
            {
                case TipoUsuarioDefaultValues.Administrador:
                    retorno = "Administrador";
                    break;
                case TipoUsuarioDefaultValues.Medico:
                    retorno = "Medico";
                    break;
                case TipoUsuarioDefaultValues.Paciente:
                    retorno = "Paciente";
                    break;
            }

            return retorno;
        }
    }
    public enum TipoUsuarioDefaultValues
    {
        Administrador,
        Medico,
        Paciente
    }
}
