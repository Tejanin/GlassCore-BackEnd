namespace GlassCoreWebAPI.Models.DTOs.EstudianteDTOs
{
    public class ShowEstudianteDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public long UserName { get; set; }
        public string Carrera { get; set; }
        public decimal Indice { get; set; }
        public int Trimestre { get; set; }
        public decimal IndiceTrimestral { get; set; }
         public string Honor { get; set; }
    }
}
