using System;
using System.Collections.Generic;

namespace GlassCoreWebAPI.Models;

public partial class Estudiante
{
    public int IdEstudiante { get; set; }

    public int IdUsuario { get; set; }

    public decimal IndiceGeneral { get; set; }

    public decimal IndiceTrimestral { get; set; }

    public string Honor { get; set; } = null!;

    public int IdCarrera { get; set; }

    public int Epoints { get; set; }

    public int Trimestre { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Carrera IdCarreraNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
