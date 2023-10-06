using System;
using System.Collections.Generic;

namespace GlassCoreWebAPI.Models;

public partial class Carrera
{
    public int IdCarrera { get; set; }

    public string NombreCarrera { get; set; } = null!;

    public int Permanencia { get; set; }

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
