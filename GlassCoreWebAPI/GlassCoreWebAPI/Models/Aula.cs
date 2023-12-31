﻿using System;
using System.Collections.Generic;

namespace GlassCoreWebAPI.Models;

public partial class Aula
{
    public int IdAula { get; set; }

    public string NombreAula { get; set; } = null!;

    public virtual ICollection<SeccionHorario> SeccionHorarios { get; set; } = new List<SeccionHorario>();
}
