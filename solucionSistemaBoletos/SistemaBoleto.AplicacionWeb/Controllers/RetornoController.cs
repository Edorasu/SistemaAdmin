using Microsoft.AspNetCore.Mvc;

namespace SistemaBoleto.AplicacionWeb.Controllers
{
    public class RetornoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
