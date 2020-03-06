using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.DatabaseFirst.Interfaces;
using Senai.InLock.WebApi.DatabaseFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DatabaseFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        public IEstudioRepository _estudioRepository;
        public IJogoRepository _jogoRepository;

        public EstudiosController()
        {
            _jogoRepository = new JogoRepository();
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var retorno = _estudioRepository.GetAll();

            return Ok(retorno);
        }
        [HttpGet("jogos")]
        public IActionResult BuscarTodosComJogos()
        {
            var estudios = _estudioRepository.GetAll();
            var jogos = _jogoRepository.GetAll();

            estudios.ForEach(x =>
            {
                x.Jogos = jogos.Where(j => j.EstudioId == x.Id).ToList();
            });

            //estudios.Select(x => new
            //{
            //    x.Id,
            //    x.Descricao,
            //    a = jogos.Where(j => j.EstudioId == x.Id).ToList()
            //});

            return Ok(estudios);
        }
    }
}
