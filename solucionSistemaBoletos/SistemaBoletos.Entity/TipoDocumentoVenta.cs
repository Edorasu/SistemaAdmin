using System;
using System.Collections.Generic;

namespace SistemaBoletos.Entity;

public partial class TipoDocumentoVenta
{
    public int IdTipoDocumentoVenta { get; set; }

    public string? Descripcion { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<VentaBoleto> VentaBoletos { get; set; } = new List<VentaBoleto>();
}
