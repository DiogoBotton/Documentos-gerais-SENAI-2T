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

        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        public IActionResult GetAll()
        {

        }
    }
}
