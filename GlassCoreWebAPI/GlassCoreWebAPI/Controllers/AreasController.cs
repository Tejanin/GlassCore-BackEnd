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
    public class AreasController : ControllerBase
    {
        private readonly AreaService _areaService;

        public AreasController(AreaService areaService)
        {
            _areaService = areaService;
        }

        // GET: api/Areas
        [HttpGet]
        public ActionResult<IEnumerable<Area>> GetAreas()
        {
          
            return Ok(_areaService.GetAll());
        }

       
    }
}
