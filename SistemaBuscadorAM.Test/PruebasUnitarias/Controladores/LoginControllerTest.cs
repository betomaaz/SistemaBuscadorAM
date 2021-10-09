using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBuscadorAM.Controllers;
using SistemaBuscadorAM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBuscadorAM.Test.PruebasUnitarias.Controladores
{
    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod]
        public async Task LoginModeloInvalido()
        {
            //preparación
            var loginRepository = new LoginRepositoryEFFalse();
            var model = new LoginViewModel() {Usuario="", Password=""};

            //ejecución
            var controller = new LoginController(loginRepository);
            controller.ModelState.AddModelError(string.Empty, "Datos Inválidos");
            var resultado = await controller.Login(model) as ViewResult;

            //verificación
            Assert.AreEqual(resultado.ViewName, "Index");
        }

        [TestMethod]
        public async Task LoginUsuarioNoExiste()
        {
            //preparación
            var loginService = new LoginRepositoryEFFalse();
            var model = new LoginViewModel() { Usuario = "Usuario1", Password = "Password1" };

            //ejecución
            var controller = new LoginController(loginService);
            var resultado = await controller.Login(model) as ViewResult;

            //verificación
            Assert.AreEqual(resultado.ViewName, "Index");
        }

        [TestMethod]
        public async Task LoginUsuarioExiste()
        {
            //preparación
            var loginService = new LoginRepositoryEFTrue();
            var model = new LoginViewModel() { Usuario = "Usuario1", Password = "Password1" };

            //ejecución
            var controller = new LoginController(loginService);
            var resultado = await controller.Login(model) as RedirectToActionResult;

            //verificación
            Assert.AreEqual(resultado.ActionName, "Index");
            Assert.AreEqual(resultado.ControllerName, "Home");


        }
    }
}
