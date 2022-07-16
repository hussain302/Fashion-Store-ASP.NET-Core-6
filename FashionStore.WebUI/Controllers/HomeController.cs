using FashionStore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FashionStore.WebUI.Controllers
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
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");

            if(ViewBag.Role != null && ViewBag.Role == "Admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        public IActionResult Privacy()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");

            if (ViewBag.Role != null && ViewBag.Role == "Admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}