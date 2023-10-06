namespace GlassCoreWebAPI.Models.DTOs.UsuarioDTOs
{
    public class MostrarUsuarioDTO
    {
        public string NombreUsuario { get; set; } = null!;
        public string ApellidoUsuario { get; set; } = null!;
        public int UserName { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Rol { get; set; } = null!;
        public string Estado { get; set; } = null!;


    }
}
