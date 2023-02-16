using System;
using System.Collections.Generic;

namespace CreacionEncuesta.Models;

public partial class Encuestum
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string DetalleEncuesta { get; set; } = null!;

    public int UsuarioRegistro { get; set; }

    public int EstadoRegistro { get; set; }
}
