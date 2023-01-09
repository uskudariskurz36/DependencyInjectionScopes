using DependencyInjectionScopes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencyInjectionScopes.Controllers
{
    public class HomeController : Controller
    {
        private IMyManager _myManager;

        public HomeController(IMyManager myManager)
        {
            _myManager = myManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy([FromServices]IMyManager myManager)
        {
            _myManager.Value = 40;
            myManager.Value = 60;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}