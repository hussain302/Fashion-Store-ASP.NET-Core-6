using FashionStore.Mappers.ProductMappers;
using FashionStore.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FashionStore.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IProductRepository service;

        public CustomerController(IProductRepository service)
        {
            this.service = service;
        }
        public IActionResult Homepage()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            //ViewBag.Role = HttpContext.Session.GetString("Role");
            return View();
        } 
        
        public IActionResult Men()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            var model = service.GetMensProducts().Select(x => x.ConvertToWebMenORWomenModel());
            return View(model);
        }
        public IActionResult Women()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            var model = service.GetWomensProducts().Select(x => x.ConvertToWebMenORWomenModel());
            return View(model);
        } 
        public IActionResult Kids()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            var model = service.GetKidsProducts().Select(x => x.ConvertToWebMenORWomenModel());
            return View(model);
        }
        public IActionResult Fragrances()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            var model = service.GetFragrancesProducts().Select(x => x.ConvertToFragranceViewModel());
            return View(model);
        }

        public IActionResult Details(int id)
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            var model = service.GetProduct(id).ConvertToWebMenORWomenModel();
            return View(model);
        }

    }
}
