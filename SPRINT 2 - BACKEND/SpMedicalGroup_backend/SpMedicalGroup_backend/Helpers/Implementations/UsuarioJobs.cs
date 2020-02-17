using SpMedicalGroup_backend.DefaultValues;
using SpMedicalGroup_backend.Domains;
using SpMedicalGroup_backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Helpers.Implementations
{
    public class UsuarioJobs : IJobs
    {
        public readonly IUsuarioRepository _usuarioRepository;
        public readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public UsuarioJobs(IUsuarioRepository usuarioRepository, ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        public async Task ExecuteAsync()
        {
            //Cria primeiro registro ADMIN na tabela de usuários
            var usuarioAdmDb = _usuarioRepository.FindByEmail("admin@email.com");

            if(usuarioAdmDb == null)
            {
                var tipoUsuarioString = TipoUsuarioDefaultValuesAcess.GetValue(TipoUsuarioDefaultValues.Administrador);
                var tipoUsuarioDb = _tipoUsuarioRepository.FindByDescricao(tipoUsuarioString);

                var nome = "Admin Padrão";
                var email = "admin@email.com";
                var senha = "admin123";

                Usuario novoUsuarioAdm = new Usuario(nome, email, senha, tipoUsuarioDb.Id);

                var usuarioRetorno = _usuarioRepository.Create(novoUsuarioAdm);
                await _usuarioRepository.UnitOfWork.SaveDbChanges();
            }

        }
    }
}
