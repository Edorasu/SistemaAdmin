using System;
using System.Collections.Generic;

namespace SistemaBoletos.Entity;

public partial class DetalleVenta
{
    public int IdDetalleVenta { get; set; }

    public int? IdVentaBoleto { get; set; }

    public int? NumeroBoleto { get; set; }

    public int? IdIda { get; set; }

    public DateTime? FechaIda { get; set; }

    public int? IdRetorno { get; set; }

    public DateTime? FechaRetorno { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Total { get; set; }

    public virtual Ida? IdIdaNavigation { get; set; }

    public virtual Retorno? IdRetornoNavigation { get; set; }

    public virtual VentaBoleto? IdVentaBoletoNavigation { get; set; }
}
