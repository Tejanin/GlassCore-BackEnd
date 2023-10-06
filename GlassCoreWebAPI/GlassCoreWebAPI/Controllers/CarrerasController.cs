using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlassCoreWebAPI.Models;
using GlassCoreWebAPI.Services;

namespace GlassCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrerasController : ControllerBase
    {
        private readonly CarreraService _carreraService;

        public CarrerasController(CarreraService carreraService)
        {
            _carreraService = carreraService;
        }

        // GET: api/Carreras
        [HttpGet]
        public ActionResult<IEnumerable<Carrera>> GetCarreras()
        {
            return Ok(_carreraService.GetAll());
        }

        // GET: api/Carreras/5
        
    }
}
