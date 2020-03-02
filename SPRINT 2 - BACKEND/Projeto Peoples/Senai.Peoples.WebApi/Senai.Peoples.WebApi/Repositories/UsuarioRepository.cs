using Senai.Peoples.WebApi.Context;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        public readonly PeoplesContext _context;

        public UsuarioRepository(PeoplesContext context)
        {
            _context = context;
        }

        public Usuario BuscarPorNomeEmail(Usuario usuario)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email && x.Senha == usuario.Senha);
        }

        public Usuario Create(Usuario usuario)
        {
            var retorno = _context.Usuarios.Add(usuario).Entity;
            _context.SaveChanges();

            return retorno;
        }

        public void Delete(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario Update(Usuario usuario)
        {
            var retorno = _context.Update(usuario).Entity;

            _context.SaveChanges();
            return retorno;
        }
    }
}
