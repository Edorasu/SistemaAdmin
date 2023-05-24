using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaBoletos.Entity;

namespace SistemaBoletos.DAL.Interfaces
{
    public interface IVentaRepository : IGenericRepository<VentaBoleto>
    {
        Task<VentaBoleto> Registrar(VentaBoleto entidad);
        Task<List<DetalleVenta>> Reporte(DateTime FechaInicio, DateTime FechaFin);
    }
}
