﻿using Microsoft.AspNetCore.Mvc;

namespace SistemaBoleto.AplicacionWeb.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
