using System;
using System.Collections.Generic;

namespace SistemaBoletos.Entity;

public partial class DetalleReserva
{
    public int IdDetalleReserva { get; set; }

    public int? IdReserva { get; set; }

    public int? IdIda { get; set; }

    public DateTime? FechaIda { get; set; }

    public int? IdRetorno { get; set; }

    public DateTime? FechaRetorno { get; set; }

    public virtual Ida? IdIdaNavigation { get; set; }

    public virtual Reserva? IdReservaNavigation { get; set; }

    public virtual Retorno? IdRetornoNavigation { get; set; }
}
