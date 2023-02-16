using System;
using System.Collections.Generic;

namespace CreacionEncuesta.Models;

public partial class RespuestaEncuestum
{
    public int Id { get; set; }

    public string? IdResultaEncuesta { get; set; }

    public string? NombrePerson { get; set; }

    public string? IdDetalleEncuesta { get; set; }

    public string? Respuesta { get; set; }
}
