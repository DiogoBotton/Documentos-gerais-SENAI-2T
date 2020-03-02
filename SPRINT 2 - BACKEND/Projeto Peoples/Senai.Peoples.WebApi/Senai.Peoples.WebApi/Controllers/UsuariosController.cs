using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Context;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IUsuario _usuarioRepository;
        public PeoplesContext _context;

        public UsuariosController()
        {
            _context = new PeoplesContext();
            _usuarioRepository = new UsuarioRepository(_context);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var retorno = _usuarioRepository.GetAll();

            return Ok(retorno);
        }

        //Cadastro autorizado apenas à administradores
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult PostCadastro(Usuario usuario)
        {
            var retorno = _usuarioRepository.Create(usuario);
            return Ok(retorno);
        }
    }
}
