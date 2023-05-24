using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SistemaBoletos.DAL.DBContext;
using SistemaBoletos.DAL.Interfaces;
using SistemaBoletos.Entity;

namespace SistemaBoletos.DAL.Implementacion
{
    public class PagoRepository : GenericRepository<Pago>, IPagoRepository
    {

        private readonly DbventaboletosContext _dbContext;

        public PagoRepository(DbventaboletosContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pago> Registrar(Pago entidad)
        {
            Pago pagoGenerado = new Pago();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetallePago dv in entidad.DetallePagos)
                    {

                    }

                    await _dbContext.SaveChangesAsync();

                    NumeroCorrelativo correlativo = _dbContext.NumeroCorrelativos.Where(n => n.Gestion == "pago").First();

                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaActualizacion = DateTime.Now;

                    _dbContext.NumeroCorrelativos.Update(correlativo);
                    await _dbContext.SaveChangesAsync();

                    string ceros = string.Concat(Enumerable.Repeat("0", correlativo.CantidadDigitos.Value));
                    string numeroPago = ceros + correlativo.UltimoNumero.ToString();
                    numeroPago = numeroPago.Substring(numeroPago.Length - correlativo.CantidadDigitos.Value, correlativo.CantidadDigitos.Value);

                    entidad.NumeroPago = numeroPago;

                    await _dbContext.AddAsync(entidad);
                    await _dbContext.SaveChangesAsync();

                    pagoGenerado = entidad;

                    transaction.Commit();


                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }

            return pagoGenerado;
        }

        public async Task<List<DetallePago>> Reporte(DateTime FechaInicio, DateTime FechaFin)
        {
            List<DetallePago> listaResumen = await _dbContext.DetallePagos
                .Include(p => p.IdPagoNavigation)
                .ThenInclude(u => u.IdUsuarioNavigation)
                .Include(p => p.IdPagoNavigation)
                .Where(dp => dp.IdPagoNavigation.FechaRegistro.Value.Date >= FechaInicio.Date &&
                    dp.IdPagoNavigation.FechaRegistro.Value.Date <= FechaFin.Date).ToListAsync();

            return listaResumen;
        }
    }
}
