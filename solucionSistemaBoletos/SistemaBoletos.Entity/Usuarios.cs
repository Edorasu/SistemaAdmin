using System;
using System.Collections.Generic;

namespace SistemaBoletos.Entity;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string? Codigo { get; set; }

    public string? Documento { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public int? IdRol { get; set; }

    public string? UrlFoto { get; set; }

    public string? NombreFoto { get; set; }

    public string? Clave { get; set; }

    public string? LugarVive { get; set; }

    public string? LugarTrabajo { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<VentaBoleto> VentaBoletos { get; set; } = new List<VentaBoleto>();
}
