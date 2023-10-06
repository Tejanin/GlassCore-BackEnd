using AutoMapper;
using GlassCoreWebAPI.Models;
using GlassCoreWebAPI.Models.DTOs.AulaDTOs;
using GlassCoreWebAPI.Models.DTOs.ErrorDTOs;
using GlassCoreWebAPI.Repositories;
using GlassCoreWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlassCoreWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AulaController : ControllerBase
    {

   
        private readonly ILogger<AulaController> _logger;
        private readonly AulaService _aulaService;

        public AulaController(ILogger<AulaController> logger, AulaService aulaService)
        {
            _logger = logger;
            _aulaService = aulaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Aula>> Get()
        {

            return Ok(_aulaService.GetAll());
           
        }

        [HttpPost]
        public ActionResult<Aula> Post(CreateAulaDTO aulaDTO)
        {
            try
            {
                return Ok(_aulaService.Create(aulaDTO));
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new ErrorDTO(e.Message));
            }
            
        }
    }
}