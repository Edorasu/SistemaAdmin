using System;
using System.Collections.Generic;

namespace SistemaBoletos.Entity;

public partial class Clientes
{
    public int IdCliente { get; set; }

    public string? DocumentoPasaporte { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Nacionalidad { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
