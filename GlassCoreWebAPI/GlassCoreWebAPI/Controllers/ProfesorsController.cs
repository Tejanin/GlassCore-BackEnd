using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlassCoreWebAPI.Models;
using GlassCoreWebAPI.Services;
using GlassCoreWebAPI.Models.DTOs.ProfesorDTOs;

namespace GlassCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorsController : ControllerBase
    {
        //private readonly GlassCoreContext _context;
        private readonly ProfesorService _profesorService;
        public ProfesorsController( ProfesorService profesorService)
        {
           
            _profesorService = profesorService;
        }

       
        [HttpPost]
        public ActionResult<Profesor> PostProfesor(CrearProfesorDTO profesorDTO)
        {
            return Ok(_profesorService.CreateProfesor(profesorDTO));
        }

       
        
    }
}
