using System;
using System.Collections.Generic;

namespace SistemaBoletos.Entity;

public partial class Pago
{
    public int IdPago { get; set; }

    public string? NumeroPago { get; set; }

    public int? IdUsuario { get; set; }

    public string? Documento { get; set; }

    public string? NombreCompleto { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? Total { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DetallePago> DetallePagos { get; set; } = new List<DetallePago>();

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
