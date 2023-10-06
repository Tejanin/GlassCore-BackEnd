﻿using AutoMapper;
using GlassCoreWebAPI.Models;
using GlassCoreWebAPI.Models.DTOs.AulaDTOs;
using GlassCoreWebAPI.Models.DTOs.UsuarioDTOs;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GlassCoreWebAPI.Interface;

namespace GlassCoreWebAPI.Services
{
    public class UsuarioService
    {
        private readonly IRepository<Usuario> _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        // Inyecto el mapper y el repositorio declarandolos como parametros en el constructor del servicio
        public UsuarioService(IRepository<Usuario> repository, IMapper mapper, IConfiguration configuration) 
        {
            _repository = repository;
            _mapper = mapper;   
            _configuration = configuration;
        }


        public IEnumerable<MostrarUsuarioDTO> ShowUsuarios()
        {
            var usuarios = _repository.GetAll();
            var usuariosDTO = _mapper.Map<IEnumerable<MostrarUsuarioDTO>>(usuarios);
            return usuariosDTO;
        }

        public Usuario CreateUsuario(CrearUsuarioDTO usuarioDTO)
        {
            if (CheckIfExists(usuarioDTO.Email)) // Chequeo si el usuario existe por el email
            {
                throw new InvalidOperationException("Este usuario ya existe");
            }
            if(usuarioDTO.Password != usuarioDTO.PasswordConfirmed)
            {
                throw new InvalidOperationException("Su contrasena no coincide");
            }
            
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            var salt = DateTime.Now.ToString();
            string passwordHashed = BCrypt.Net.BCrypt.EnhancedHashPassword(usuarioDTO.Password + salt, 13);
            usuario.Salt = salt;
            usuario.Password = passwordHashed;
            _repository.Create(usuario);
            return _repository.Get(a => a.Email == usuarioDTO.Email)!;
        }

        public string Login(LoginUsuarioDTO login)
        {
            var usuarioLogin = _repository.Get(u => u.UserName == login.UserName);
            string Token;
            if (usuarioLogin == null || usuarioLogin.Estado == "Inactivo")
            {
               return "Usuario no Existente";
            }

           
            bool passwordVerified = BCrypt.Net.BCrypt.EnhancedVerify(login.Password + usuarioLogin.Salt, usuarioLogin.Password);

            if (passwordVerified)
            {
                Token = GetToken(usuarioLogin);
                return Token;
            }
             ;
            return "Contrasena incorrecta";

        }

        public string GetToken(Usuario usuarioLogged)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserId", usuarioLogged.IdUsuario.ToString() ),
                new Claim("Rol", usuarioLogged.Rol),
               // new Claim("IdType", usuarioLogged.IdUsuario.ToString() ),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Bearer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signIn
                );

            string Token = new JwtSecurityTokenHandler().WriteToken(token);
            return Token;
        }

        public bool CheckIfExists(string email)
        {
            return _repository.Get(u => u.Email == email) != null;
        }
    }
}
