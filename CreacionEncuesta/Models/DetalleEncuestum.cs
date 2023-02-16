using System;
using System.Collections.Generic;

namespace CreacionEncuesta.Models;

public partial class DetalleEncuestum
{
    public int? Id { get; set; }

    public string? IdDetalle { get; set; }

    public string Nombre { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public int? Requerido { get; set; }

    public string? Resultado { get; set; }

    public int? EstadoRegistro { get; set; }
}
