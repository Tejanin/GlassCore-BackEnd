using System;
using System.Collections.Generic;

namespace GlassCoreWebAPI.Models;

public partial class Asignatura
{
    public int IdAsignatura { get; set; }

    public int NumAsignatura { get; set; }

    public string NombreAsignatura { get; set; } = null!;

    public int CodigoAsignatura { get; set; }

    public int Creditos { get; set; }

    public string Estado { get; set; } = null!;

    public virtual TipoAsignatura CodigoAsignaturaNavigation { get; set; } = null!;

    public virtual ICollection<Seccion> Seccions { get; set; } = new List<Seccion>();
}
