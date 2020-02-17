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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        public SpMedGroupContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public TipoUsuarioRepository(SpMedGroupContext context)
        {
            _context = context;
        }

        public TipoUsuario Create(TipoUsuario objeto)
        {
            return _context.TiposUsuarios.Add(objeto).Entity;
        }

        public TipoUsuario FindByDescricao(string titulo)
        {
            return _context.TiposUsuarios.FirstOrDefault(x => x.Titulo == titulo);
        }
    }
}
