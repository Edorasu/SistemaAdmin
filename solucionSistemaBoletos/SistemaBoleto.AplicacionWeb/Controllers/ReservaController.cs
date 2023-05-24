using Microsoft.AspNetCore.Mvc;

namespace SistemaBoleto.AplicacionWeb.Controllers
{
    public class ReservaController : Controller
    {
        public IActionResult NuevaReserva()
        {
            return View();
        }
        public IActionResult HistorialReserva()
        {
            return View();
        }
    }
}
