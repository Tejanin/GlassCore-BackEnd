using System;
using System.Collections.Generic;

namespace GlassCoreWebAPI.Models;

public partial class Ciclo
{
    public int IdCiclo { get; set; }

    public string DescCiclo { get; set; } = null!;

    public virtual ICollection<Seccion> Seccions { get; set; } = new List<Seccion>();
}
