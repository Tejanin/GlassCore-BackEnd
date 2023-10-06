using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlassCoreWebAPI.Models;
using GlassCoreWebAPI.Services;
using GlassCoreWebAPI.Models.DTOs.UsuarioDTOs;
using GlassCoreWebAPI.Models.DTOs.AulaDTOs;
using GlassCoreWebAPI.Models.DTOs.ErrorDTOs;

namespace GlassCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


    
        // GET: api/Usuarios
        [HttpGet]
        public  ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return Ok(_usuarioService.ShowUsuarios());
        }

        [HttpPost]
        public ActionResult<Usuario> PostUsuario(CrearUsuarioDTO usuarioDTO)
        {
            try
            {
                return Ok(_usuarioService.CreateUsuario(usuarioDTO));
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new ErrorDTO(e.Message));
            }

        }

        [HttpPost]
        [Route("/Login")]
        public ActionResult<Usuario> LoginUsuario(LoginUsuarioDTO usuarioDTO)
        {
            string res = _usuarioService.Login(usuarioDTO);


                if (res != "Usuario no Existente" && res != "Contrasena incorrecta")
                {
                    
                    return Ok("Login Existoso      " +res);
                }
                
            
           
            
                return BadRequest(res);
            

        }


        // GET: api/Usuarios/5

    }
}
