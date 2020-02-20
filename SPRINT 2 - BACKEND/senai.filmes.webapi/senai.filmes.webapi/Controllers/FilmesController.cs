using Microsoft.AspNetCore.Mvc;
using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using senai.Filmes.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FilmesController : ControllerBase
    {
        public IFilmesRepository _filmesRepository;

        public FilmesController()
        {
            _filmesRepository = new FilmeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Faz a chamada para o método .Listar();
            var result = _filmesRepository.Listar();

            //Ordena em ordem alfabética (orderBy -> Linq)
            result = result.OrderBy(x => x.Titulo).ToList();
            return Ok(result);

        }

        [HttpGet("{idGenero}")]
        public IActionResult GetbyId(int idGenero)
        {
            var result = _filmesRepository.GetById(idGenero);

            if (result == null)
                return NotFound(new
                {
                    mensagem = "Genero não encontrado.",
                    erro = true,
                });
            
            //Ou retornar StatusCode(201) - Created
            return Ok(result);
        }

        [HttpGet("{filtro}")]
        public IActionResult GetByTitulo(string filtro)
        {
            var result = _filmesRepository.GetByTitulo(filtro);
            result.OrderBy(x => x.Titulo).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain filmeDomain)
        {
            var result = _filmesRepository.Insert(filmeDomain);
            var generoViewModel = _filmesRepository.GetById(filmeDomain.IdGenero);
            return Ok(new {
                IdFilme = result.IdFilme,
                Titulo = result.Titulo,
                Genero = generoViewModel.Genero.Nome
            });
        }
        [HttpPut("{idFilme}")]
        public FilmeDomain Update(int idFilme, FilmeDomain filmeDomain)
        {
            return _filmesRepository.Update(idFilme, filmeDomain);
        }
        [HttpDelete]
        public string Delete(int idGenero)
        {
            _filmesRepository.Delete(idGenero);
            return $"{idGenero} deletado";
        }
    }
}
