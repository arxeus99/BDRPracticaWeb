using BDRPracticaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BDRPracticaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            APIConnectionHelper connectionHelper = new APIConnectionHelper();

            var paises = await connectionHelper.GetPaises();

            ViewData["paises"] = paises;

            return View();
        }

        public IActionResult NuevoPais()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearPais(Pais nuevoPais)
        {
            APIConnectionHelper connectionHelper = new APIConnectionHelper();

            await connectionHelper.InsertPais(nuevoPais);

            var paises = await connectionHelper.GetPaises();

            ViewData["paises"] = paises;

            return View("Index");
        }

        public async Task<IActionResult> ActualizarPais(Int64 IdPais)
        {

            APIConnectionHelper connectionHelper = new APIConnectionHelper();

            var pais = await connectionHelper.GetPais(IdPais);

            ViewData["Pais"] = pais;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarPais(Pais nuevoPais)
        {
            APIConnectionHelper connectionHelper = new APIConnectionHelper();

            await connectionHelper.UpdatePais(nuevoPais);

            var paises = await connectionHelper.GetPaises();

            ViewData["paises"] = paises;

            return View("Index");
        }

        public async Task<string> BorrarPais(Int64 IdPais)
        {
            APIConnectionHelper connectionHelper = new APIConnectionHelper();

            return await connectionHelper.DeletePais(IdPais);

        }
    }
}
