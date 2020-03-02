using Microsoft.AspNetCore.Mvc;
using Senai.Inlock.WebApi.Contexts;
using Senai.Inlock.WebApi.Interfaces;
using Senai.Inlock.WebApi.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class JogosController : ControllerBase
    {
        public IJogoRepository _jogoRepository { get; set; }
        public IEstudioRepository _estudioRepository { get; set; }
        public InLockContext _context { get; set; }

        public JogosController()
        {
            _context = new InLockContext();
            _jogoRepository = new JogoRepository(_context);
            _estudioRepository = new EstudioRepository(_context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var retorno = _jogoRepository.GetAll();

            var estudios = _estudioRepository.GetAll();
            var retornao = retorno.Select(x =>
            {
                x.EstudioVM = estudios.FirstOrDefault(e => e.Id == x.EstudioId); 
            }).ToList();
        }
    }
}
