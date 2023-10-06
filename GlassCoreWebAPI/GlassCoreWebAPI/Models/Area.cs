using System;
using System.Collections.Generic;

namespace GlassCoreWebAPI.Models;

public partial class Area
{
    public int IdArea { get; set; }

    public string NombreArea { get; set; } = null!;

    public virtual ICollection<Profesor> Profesors { get; set; } = new List<Profesor>();
}
