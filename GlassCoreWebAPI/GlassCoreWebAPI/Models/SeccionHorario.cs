using System;
using System.Collections.Generic;

namespace GlassCoreWebAPI.Models;

public partial class SeccionHorario
{
    public int Id { get; set; }

    public int IdSeccion { get; set; }

    public int IdAula { get; set; }

    public TimeSpan? HoraInicio { get; set; }

    public TimeSpan? HoraSalida { get; set; }

    public int? IdDia { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Aula IdAulaNavigation { get; set; } = null!;

    public virtual Dium? IdDiaNavigation { get; set; }

    public virtual Seccion IdSeccionNavigation { get; set; } = null!;
}
