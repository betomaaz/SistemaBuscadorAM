using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaBuscadorAM.Filters;
using SistemaBuscadorAM.Models;
using SistemaBuscadorAM.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscadorAM.Controllers
{
    [ServiceFilter(typeof(SessionFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
                        
        public IActionResult Privacy()
        {
            //OnActionExecuting
            
            return View();
            //OnActionExecuted
        }

        public IActionResult Prueba()
        {
            string sessionId = Request.Cookies["sessionId"];
            if (string.IsNullOrEmpty(sessionId) || !sessionId.Equals(HttpContext.Session.GetString("sessionId")))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
