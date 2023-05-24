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
    public class ReservaRepository : GenericRepository<Reserva>, IReservaRepository
    {
        private readonly DbventaboletosContext _dbContext;

        public ReservaRepository(DbventaboletosContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Reserva> Registrar(Reserva entidad)
        {
            Reserva reservaGenerada = new Reserva();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleReserva dv in entidad.DetalleReservas)
                    {

                    }

                    await _dbContext.SaveChangesAsync();

                    NumeroCorrelativo correlativo = _dbContext.NumeroCorrelativos.Where(n => n.Gestion == "reserva").First();

                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaActualizacion = DateTime.Now;

                    _dbContext.NumeroCorrelativos.Update(correlativo);
                    await _dbContext.SaveChangesAsync();

                    string ceros = string.Concat(Enumerable.Repeat("0", correlativo.CantidadDigitos.Value));
                    string numeroReserva = ceros + correlativo.UltimoNumero.ToString();
                    numeroReserva = numeroReserva.Substring(numeroReserva.Length - correlativo.CantidadDigitos.Value, correlativo.CantidadDigitos.Value);

                    entidad.NumeroReserva = numeroReserva;

                    await _dbContext.AddAsync(entidad);
                    await _dbContext.SaveChangesAsync();

                    reservaGenerada = entidad;

                    transaction.Commit();


                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }

            return reservaGenerada;
        }

        public async Task<List<DetalleReserva>> Reporte(DateTime FechaInicio, DateTime FechaFin)
        {
            List<DetalleReserva> listaResumen = await _dbContext.DetalleReservas
                .Include(r => r.IdReservaNavigation)
                .ThenInclude(u => u.IdUsuarioNavigation)
                .Include(r => r.IdReservaNavigation)
                .ThenInclude(tdr => tdr.IdTipoDocumentoVentaNavigation)
                .Where(dr => dr.IdReservaNavigation.FechaRegistro.Value.Date >= FechaInicio.Date &&
                    dr.IdReservaNavigation.FechaRegistro.Value.Date <= FechaFin.Date).ToListAsync();

            return listaResumen;
        }
    }
}
