using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.DefaultValues
{
    public class StatusConsultaDefaultValuesAcess
    {
        //Método que quando chamado retorna uma string, caso tipo de ValorPadrao existir
        public static string GetValue(StatusConsultaDefaultValues statusConsultaDefaultValues)
        {
            string retorno = null;
            switch (statusConsultaDefaultValues)
            {
                case StatusConsultaDefaultValues.Agendada:
                    retorno = "Agendada";
                    break;
                case StatusConsultaDefaultValues.Realizada:
                    retorno = "Realizada";
                    break;
                case StatusConsultaDefaultValues.Cancelada:
                    retorno = "Cancelada";
                    break;
                default:
                    break;
            }
            
            return retorno;
        }
    }
    public enum StatusConsultaDefaultValues
    {
        Agendada,
        Realizada,
        Cancelada
    }
}
