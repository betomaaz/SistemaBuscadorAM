using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaBuscadorAM.Models;
using SistemaBuscadorAM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscadorAM.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var repo = new LoginRepository();
            if (ModelState.IsValid)
            {
                if (await repo.UserExist(model.Usuario, model.Password))
                {
                    Guid sessionId = Guid.NewGuid();
                    HttpContext.Session.SetString("sessionId", sessionId.ToString());
                    Response.Cookies.Append("sessionId", sessionId.ToString());
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario o contraseña no es válido");
                }
            }

            return View("Index", model);
        }
    }
}
