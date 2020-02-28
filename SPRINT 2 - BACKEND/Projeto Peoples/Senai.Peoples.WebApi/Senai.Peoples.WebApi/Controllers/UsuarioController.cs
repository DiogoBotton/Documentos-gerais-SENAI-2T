using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Peoples.WebApi.Context;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IUsuario _usuarioRepository { get; set; }
        public PeoplesContext _context;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository(_context);
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            var retorno = _usuarioRepository.BuscarPorNomeEmail(usuario);

            if (retorno == null)
                return NotFound("Nome e/ou senha inválidos.");

            var informacoesUsuario = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()), // Jti claimName para ID's
                new Claim(ClaimTypes.Role, usuario.TipoUsuarioId.ToString())
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("peoples-chave-autenticacao"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gera o token
            var token = new JwtSecurityToken(
                issuer: "Senai.Peoples.WebApi",         // emissor do token
                audience: "Senai.Peoples.WebApi",       // destinatário do token
                claims: informacoesUsuario,             // dados definidos acima
                expires: DateTime.Now.AddMinutes(30),   // tempo de expiração
                signingCredentials: creds               // credenciais do token
            );

            return Ok(new {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
