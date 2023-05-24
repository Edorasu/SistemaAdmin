using Microsoft.AspNetCore.Mvc;

namespace SistemaBoleto.AplicacionWeb.Controllers
{
    public class PagosController : Controller
    {
        public IActionResult NuevoPago()
        {
            return View();
        }

        public IActionResult HistorialPago()
        {
            return View();
        }
    }
}
