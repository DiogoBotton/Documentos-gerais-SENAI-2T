using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        public IFuncionario _funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        /// <summary>
        /// Lista de funcionários desc or asc
        /// </summary>
        /// <param name="ordem"></param>
        /// <returns>Retorna uma lista de todos os funcionários em ordem decrescente ou crescente</returns>
        [HttpGet("ordem/{ordem}")]
        public IActionResult GetDescOrAsc(string ordem)
        {
            if (ordem != "asc" && ordem != "desc")
                return BadRequest("Escolha uma ordenação válida 'desc' ou 'asc'");

            var result = _funcionarioRepository.Listar();

            if(ordem == "asc")
                result = result.OrderBy(x => x.Nome).ToList();

            if (ordem == "desc")
                result = result.OrderByDescending(x => x.Nome).ToList();

            return Ok(result);

        }

        /// <summary>
        /// Buscar Todos os funcionários
        /// </summary>
        /// <returns>Retorna todos os usuários</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Faz a chamada para o método .Listar();
            var result = _funcionarioRepository.Listar();

            //Ordena em ordem alfabética (orderBy -> Linq)
            result = result.OrderBy(x => x.Nome).ToList();
            return Ok(result);

        }
        /// <summary>
        /// Buscar funcionário por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o funcíonário baseado no id</returns>
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            Funcionario result = _funcionarioRepository.GetById(id);

            if (result == null)
                return NotFound(new
                {
                    mensagem = "Funcionário não encontrado.",
                    erro = true,
                });

            //Ou retornar StatusCode(201) - Created
            return Ok(result);
        }

        /// <summary>
        /// Busca por nome de funcionário
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns>Retorna uma lista de funcionários baseado no nome ou sobrenome</returns>
        [HttpGet("filtro/{filtro}")]
        public IActionResult GetByNome(string filtro)
        {
            var result = _funcionarioRepository.GetByNome(filtro);
            result.OrderBy(x => x.Nome).ToList();

            var listaNomeCompleto = result.Select(x => new
            {
                nomeCompleto = $"{x.Nome} {x.Sobrenome}"
            }).ToList();

            return Ok(listaNomeCompleto);
        }

        /// <summary>
        /// Cadastra um funcionário
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Retorna um IActionResult com o usuario cadastrado</returns>
        /// <response code="201">Funcionário criado</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public IActionResult Post(Funcionario funcionario)
        {
            if (string.IsNullOrEmpty(funcionario.Nome) || string.IsNullOrEmpty(funcionario.Sobrenome))
                return BadRequest("Valores 'Nome' e/ou 'Sobrenome' vazios.");

            var result = _funcionarioRepository.Insert(funcionario);
            return Created(" http://localhost:5000/api/Funcionarios", result);
        }

        /// <summary>
        /// Atualiza as informações de um usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="funcionario"></param>
        /// <returns>Retorna o usuário atualizado</returns>
        [HttpPut("{id}")]
        public Funcionario Update(int id, Funcionario funcionario)
        {
            return _funcionarioRepository.Update(id, funcionario);
        }

        /// <summary>
        /// Deletar um funcionário por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna uma string de confirmação de ação caso for deletado</returns>
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _funcionarioRepository.Delete(id);
            return $"{id} deletado";
        }
    }
}
