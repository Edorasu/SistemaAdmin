using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaBoletos.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using SistemaBoletos.DAL.Interfaces;
using SistemaBoletos.DAL.Implementacion;
//using SistemaBoletos.BLL.Interfaces;
//using SistemaBoletos.BLL.Implementacion;


namespace SistemaBoletos.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbventaboletosContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("CadenaSQL"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(IGenericRepository<>));
            services.AddScoped<IVentaRepository, VentaRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();
            services.AddScoped<IPagoRepository, PagoRepository>();
        }
    }
}
