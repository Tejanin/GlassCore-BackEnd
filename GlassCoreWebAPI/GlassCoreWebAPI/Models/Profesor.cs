using System;
using System.Collections.Generic;

namespace GlassCoreWebAPI.Models;

public partial class Profesor
{
    public int IdProfesor { get; set; }

    public int IdUsuario { get; set; }

    public int IdArea { get; set; }

    public virtual Area IdAreaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Seccion> Seccions { get; set; } = new List<Seccion>();
}
