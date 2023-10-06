namespace GlassCoreWebAPI.Models.DTOs.EstudianteDTOs
{
    public class RankingDTO
    {
          public string NombreUsuario { get; set; } = null!;
          public string ApellidoUsuario { get; set; } = null!;

        
        public long UserName { get; set; } 
        public decimal IndiceGeneral { get; set; } 
        public int Trimestre { get;set; }
        public string NombreCarrera { get; set; } = null!;
    }
}

    
     

