using System;
using System.Collections.Generic;

namespace SistemaBoletos.Entity;

public partial class DetallePago
{
    public int IdDetallePago { get; set; }

    public int? IdPago { get; set; }

    public DateTime? MesPago { get; set; }

    public decimal? Pago { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? Total { get; set; }

    public virtual Pago? IdPagoNavigation { get; set; }
}
