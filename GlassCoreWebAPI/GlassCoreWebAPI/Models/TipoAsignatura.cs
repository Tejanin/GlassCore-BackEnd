using System;
using System.Collections.Generic;

namespace GlassCoreWebAPI.Models;

public partial class TipoAsignatura
{
    public int CodigoAsignatura { get; set; }

    public string Codigo { get; set; } = null!;

    public string DescripcionAsignatura { get; set; } = null!;

    public virtual Asignatura? Asignatura { get; set; }
}
