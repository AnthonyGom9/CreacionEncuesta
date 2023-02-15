using System;
using System.Collections.Generic;

namespace CreacionEncuesta.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Nombre { get; set; } = null!;
}
