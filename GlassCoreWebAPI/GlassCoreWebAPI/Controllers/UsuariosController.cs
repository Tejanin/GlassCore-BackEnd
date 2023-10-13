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
using NuGet.Protocol.Plugins;
using GlassCoreWebAPI.Interface;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;

namespace GlassCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly GlassCoreContext _context;
        private readonly IRepository<Usuario> _repository;

        public UsuariosController(UsuarioService usuarioService, GlassCoreContext context, IRepository<Usuario> repository)
        {
            _usuarioService = usuarioService;
            _context = context;
            _repository = repository;
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
            
            var usuarioLogin = _context.Usuarios.SingleOrDefault(u => u.UserName == usuarioDTO.UserName);

            if (usuarioLogin == null || usuarioLogin.Estado == "Inactivo")
            {
                return BadRequest();
            }

            bool passwordVerified = BCrypt.Net.BCrypt.EnhancedVerify(usuarioDTO.Password + usuarioLogin.Salt, usuarioLogin.Password);

            if (passwordVerified)
            {
                var Token = _usuarioService.GetToken(usuarioLogin);
                var TokenS = new JwtSecurityTokenHandler().WriteToken(Token);

                return Ok(new {Token = TokenS});
            }

            return Unauthorized("Usuario no validado");
        }


        [HttpPut]

        public ActionResult<Usuario> PutUsuario(ModificarUsuarioDTO usuarioDTO)
        {
            return Ok(_usuarioService.Modificar(usuarioDTO));
        }


        // GET: api/Usuarios/5

    }
}
