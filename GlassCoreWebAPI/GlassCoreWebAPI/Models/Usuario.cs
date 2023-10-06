using System;
using System.Collections.Generic;

namespace GlassCoreWebAPI.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ApellidoUsuario { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public long UserName { get; set; }

    public string Password { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public byte[]? Imagen { get; set; }

    public DateTime FechaIngreso { get; set; }

    public virtual Administrador? Administrador { get; set; }

    public virtual Estudiante? Estudiante { get; set; }

    public virtual Profesor? Profesor { get; set; }
}
