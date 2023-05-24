using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaBoletos.Entity;

namespace SistemaBoletos.DAL.Interfaces
{
    public interface IReservaRepository : IGenericRepository<Reserva>
    {
        Task<Reserva> Registrar(Reserva entidad);
        Task<List<DetalleReserva>> Reporte(DateTime FechaInicio, DateTime FechaFin);
    }
}
