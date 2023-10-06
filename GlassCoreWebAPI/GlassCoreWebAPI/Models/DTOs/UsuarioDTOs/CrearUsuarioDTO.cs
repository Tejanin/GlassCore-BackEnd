using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GlassCoreWebAPI.Models.DTOs.UsuarioDTOs
{
    public class CrearUsuarioDTO
    {

        public string NombreUsuario { get; set; } = null!;
        public string ApellidoUsuario { get; set; } = null!;
        public byte[]? Imagen { get; set; }
        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string PasswordConfirmed { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }
}