using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlassCoreWebAPI.Models;
using GlassCoreWebAPI.Services;
using GlassCoreWebAPI.Models.DTOs.EstudianteDTOs;
using GlassCoreWebAPI.Models.DTOs.ErrorDTOs;

namespace GlassCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly EstudianteService _estudianteService;

        public EstudiantesController(EstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        // GET: api/Estudiantes
        [HttpGet]
        public ActionResult<IEnumerable<Estudiante>> ShowRanking()
        {
            return Ok(_estudianteService.ShowRanking());
        }

        [HttpPost]

        public ActionResult<Estudiante> PostUsuario(CrearEstudianteDTO estudianteDTO)
        {
            try
            {
                return Ok(_estudianteService.CreateEstudiante(estudianteDTO));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // GET: api/Estudiantes/5
        // [HttpGet("{id}")]


        // PUT: api/Estudiantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       
        // POST: api/Estudiantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*  [HttpPost]
          public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante estudiante)
          {
            if (_estudianteService.Estudiantes == null)
            {
                return Problem("Entity set 'GlassCoreContext.Estudiantes'  is null.");
            }
              _estudianteService.Estudiantes.Add(estudiante);
              await _estudianteService.SaveChangesAsync();

              return CreatedAtAction("GetEstudiante", new { id = estudiante.IdEstudiante }, estudiante);
          }

          // DELETE: api/Estudiantes/5
          [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteEstudiante(int id)
          {
              if (_estudianteService.Estudiantes == null)
              {
                  return NotFound();
              }
              var estudiante = await _estudianteService.Estudiantes.FindAsync(id);
              if (estudiante == null)
              {
                  return NotFound();
              }

              _estudianteService.Estudiantes.Remove(estudiante);
              await _estudianteService.SaveChangesAsync();

              return NoContent();
          }

          private bool EstudianteExists(int id)
          {
              return (_estudianteService.Estudiantes?.Any(e => e.IdEstudiante == id)).GetValueOrDefault();
          }
      }*/
    } 

}
