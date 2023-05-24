using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaBoletos.Entity;

namespace SistemaBoletos.DAL.Interfaces
{
    public interface IPagoRepository: IGenericRepository<Pago>
    {
        Task<Pago> Registrar(Pago entidad);
        Task<List<DetallePago>> Reporte(DateTime FechaInicio, DateTime FechaFin);
    }
}
