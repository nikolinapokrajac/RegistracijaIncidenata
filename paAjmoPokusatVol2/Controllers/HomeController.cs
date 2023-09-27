using Microsoft.AspNetCore.Mvc;
using paAjmoPokusat.Models;
using System.Diagnostics;

namespace paAjmoPokusatVol2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // return RedirectToAction("Login");
            //if (!(User.IsInRole(paAjmoPokusat.Utility.SD.Role_Admin)) || !(User.IsInRole(paAjmoPokusat.Utility.SD.Role_Admin)))
            //{
            //    return View("~/Areas/Identity/Pages/Account/Login.cshtml");

            //}
            //else { return View(); }
            return View();

        }
        public IActionResult Login()
        {
            return View();
            //if (!(User.IsInRole(paAjmoPokusat.Utility.SD.Role_Admin)) || !(User.IsInRole(paAjmoPokusat.Utility.SD.Role_Admin)))
            //{
            //    return View("~/Areas/Identity/Pages/Account/Login.cshtml");

            //}
            //else { return View(); }

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}