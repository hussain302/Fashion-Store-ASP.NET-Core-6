using FashionStore.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using FashionStore.Mappers.ProductMappers;
using FashionStore.Model.Models;

namespace FashionStore.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository context;

        public CategoryController(ICategoryRepository context)
        {
            this.context = context;
        }


        public IActionResult Manage()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");

            if (ViewBag.Role != null && ViewBag.Role == "Admin")
            {
                var models = context.GetCategories()
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

        [HttpPost]
        
        public IActionResult Create(ProductCategoryModel model)
        {

            context.AddCategory(model.ConvertToDomainModel());
            return RedirectToAction("Manage");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");

            if (ViewBag.Role != null && ViewBag.Role == "Admin")
            {
                var find = context.GetCategory(id).ConvertToWebModel();
                return View(find);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
            
        }

        [HttpPost]
        public IActionResult Edit(ProductCategoryModel model)
        {

            context.UpdateCategory(model.ConvertToDomainModel());
            return RedirectToAction("Manage");
        }
        public IActionResult Delete(int id)
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if (ViewBag.Role != null && ViewBag.Role == "Admin")
            {
                var find = context.GetCategory(id).ConvertToWebModel();
                return View(find);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpPost]
        public IActionResult Delete(ProductCategoryModel model)
        {
            context.DeleteCategory(model.Id);
            return RedirectToAction("Manage");
        }

    }
}
