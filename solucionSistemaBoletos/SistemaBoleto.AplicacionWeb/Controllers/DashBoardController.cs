using Microsoft.AspNetCore.Mvc;

namespace SistemaBoleto.AplicacionWeb.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
