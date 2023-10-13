using System;
using System.Collections.Generic;

namespace GlassCoreWebAPI.Models;

public partial class Dium
{
    public int IdDia { get; set; }

    public string NombreDia { get; set; } = null!;

    public virtual ICollection<SeccionHorario> SeccionHorarios { get; set; } = new List<SeccionHorario>();
}
