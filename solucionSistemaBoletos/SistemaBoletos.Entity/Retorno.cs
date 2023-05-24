using System;
using System.Collections.Generic;

namespace SistemaBoletos.Entity;

public partial class Retorno
{
    public int IdRetorno { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DetalleReserva> DetalleReservas { get; set; } = new List<DetalleReserva>();

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
}
