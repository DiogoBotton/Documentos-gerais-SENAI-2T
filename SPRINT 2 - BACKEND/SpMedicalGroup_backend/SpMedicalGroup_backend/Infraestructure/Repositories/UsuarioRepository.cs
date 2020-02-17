using SpMedicalGroup_backend.Domains;
using SpMedicalGroup_backend.Infraestructure.Contexts;
using SpMedicalGroup_backend.Interfaces;
using SpMedicalGroup_backend.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup_backend.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public SpMedGroupContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public UsuarioRepository(SpMedGroupContext context)
        {
            _context = context;
        }

        public Usuario Create(Usuario objeto)
        {
            return _context.Usuarios.Add(objeto).Entity;
        }

        public Usuario FindByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email == email);
        }
    }
}
