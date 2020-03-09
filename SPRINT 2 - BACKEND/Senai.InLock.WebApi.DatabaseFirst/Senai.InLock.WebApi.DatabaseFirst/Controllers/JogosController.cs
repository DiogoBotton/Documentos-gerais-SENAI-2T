using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.DatabaseFirst.Domains;
using Senai.InLock.WebApi.DatabaseFirst.Interfaces;
using Senai.InLock.WebApi.DatabaseFirst.Repositories;

namespace Senai.InLock.WebApi.DatabaseFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        public IJogoRepository _jogoRepository;

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpPut]
        public IActionResult Update(Jogos jogoAtt)
        {
            var jogo = _jogoRepository.GetById(jogoAtt.Id);

            if (jogo == null)
                return NotFound($"Não existe jogo id {jogoAtt.Id}.");

            jogo.AlterarInformacoes(jogoAtt.Nome, jogoAtt.Descricao, jogoAtt.DataLancamento, jogoAtt.Valor, jogoAtt.EstudioId);

            _jogoRepository.UpdatePath(jogo);

            return Ok(jogo);
        }
    }
}