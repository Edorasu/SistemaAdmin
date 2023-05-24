using Microsoft.AspNetCore.Mvc;

namespace SistemaBoleto.AplicacionWeb.Controllers
{
    public class ReportePagosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
