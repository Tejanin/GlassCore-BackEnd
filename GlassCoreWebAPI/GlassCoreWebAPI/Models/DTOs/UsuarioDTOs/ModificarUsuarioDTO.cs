namespace GlassCoreWebAPI.Models.DTOs.UsuarioDTOs
{
    public class ModificarUsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? ApellidoUsuario { get; set; } 

        public string? Email { get; set; }

        public string? Estado { get; set; }


    }
}
