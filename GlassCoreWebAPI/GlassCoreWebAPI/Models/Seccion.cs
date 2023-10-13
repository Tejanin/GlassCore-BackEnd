using System;
using System.Collections.Generic;

namespace GlassCoreWebAPI.Models;

public partial class Seccion
{
    public int IdSeccion { get; set; }

    public int IdAsignatura { get; set; }

    public int? NumSeccion { get; set; }

    public int? IdProfesor { get; set; }

    public int? IdCiclo { get; set; }

    public int? Ano { get; set; }

    public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;

    public virtual Ciclo? IdCicloNavigation { get; set; }

    public virtual Profesor? IdProfesorNavigation { get; set; }

    public virtual ICollection<SeccionHorario> SeccionHorarios { get; set; } = new List<SeccionHorario>();
}
