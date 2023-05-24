using System;
using System.Collections.Generic;

namespace SistemaBoletos.Entity;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public string? NumeroReserva { get; set; }

    public int? IdTipoDocumentoVenta { get; set; }

    public int? IdUsuario { get; set; }

    public string? DocumentoCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? Observaciones { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DetalleReserva> DetalleReservas { get; set; } = new List<DetalleReserva>();

    public virtual TipoDocumentoVenta? IdTipoDocumentoVentaNavigation { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
