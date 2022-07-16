using FashionStore.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using FashionStore.Mappers.ProductMappers;
using FashionStore.Model.Models;

namespace FashionStore.WebUI.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeRepository context;
        public TypeController(ITypeRepository context) {
            this.context = context;
        }
        public IActionResult Manage()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if (ViewBag.Role != null && ViewBag.Role == "Admin")
            {
                var models = context.GetTypes()
                 .Select(x => x.ConvertToWebModel()).ToList();
                return View(models);              
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
            
        }
        public IActionResult Create()
        {
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
        [HttpPost]
        public IActionResult Create(ProductTypeModel model)
        {
            context.AddType(model.ConvertToDomainModel());
            return RedirectToAction("Manage");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if (ViewBag.Role != null && ViewBag.Role == "Admin")
            {
                var find = context.GetType(id).ConvertToWebModel();
                return View(find);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        [HttpPost]
        public IActionResult Edit(ProductTypeModel model)
        {

            context.UpdateType(model.ConvertToDomainModel());
            return RedirectToAction("Manage");
        }
        public IActionResult Delete(int id)
        {
        
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if (ViewBag.Role != null && ViewBag.Role == "Admin")
            {
                var find = context.GetType(id).ConvertToWebModel();
                return View(find);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        [HttpPost]
        public IActionResult Delete(ProductTypeModel model)
        {
            context.DeleteType(model.Id);
            return RedirectToAction("Manage");
        }
    }
}
