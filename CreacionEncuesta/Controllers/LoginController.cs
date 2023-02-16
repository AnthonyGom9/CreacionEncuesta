
using CreacionEncuesta.Models;
using CreacionEncuesta.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CreacionEncuesta.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IniciarSesion(LoginViewModel model)
        {
            Console.WriteLine(model);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(LoginViewModel model)
        {
            Console.WriteLine(model);
            return View();
        }
    }
}
