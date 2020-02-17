using SpMedicalGroup_backend.DefaultValues;
using SpMedicalGroup_backend.Domains;
using SpMedicalGroup_backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Helpers.Implementations
{
    public class StatusConsultaJobs : IJobs
    {
        public readonly IStatusConsultaRepository _statusConsultaRepository;
        public StatusConsultaJobs(IStatusConsultaRepository statusConsultaRepository)
        {
            _statusConsultaRepository = statusConsultaRepository;
        }
        public async Task ExecuteAsync()
        {
            for (int i = 0; i < 3; i++)
            {
                var statusCasting = (StatusConsultaDefaultValues)i;
                var status = StatusConsultaDefaultValuesAcess.GetValue(statusCasting);

                var statusConsultaDb = _statusConsultaRepository.FindByDescricao(status);

                if(statusConsultaDb == null)
                {
                    statusConsultaDb = new StatusConsulta(status);

                    _statusConsultaRepository.Create(statusConsultaDb);
                    await _statusConsultaRepository.UnitOfWork.SaveDbChanges();
                }
            }
        }
    }
}
