using System;
using System.Collections.Generic;

namespace GlassCoreWebAPI.Models;

public partial class Horario
{
    public int IdEstudiante { get; set; }

    public int IdSeccionHorario { get; set; }

    public int? CalificacionMd { get; set; }

    public string? CalificacionFinal { get; set; }

    public int IdHorario { get; set; }

    public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;

    public virtual SeccionHorario IdSeccionHorarioNavigation { get; set; } = null!;
}
