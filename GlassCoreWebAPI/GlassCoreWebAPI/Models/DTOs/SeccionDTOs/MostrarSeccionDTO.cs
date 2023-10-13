namespace GlassCoreWebAPI.Models.DTOs.SeccionDTOs
{
    public class MostrarSeccionDTO
    {
        public int IdSeccion { get; set; }
        public int NumSeccion { get; set; }
        public string NombreAsigntura { get; set; } = null!;
        public string NombreProfesor { get; set; } = null!;

        

    }
}
