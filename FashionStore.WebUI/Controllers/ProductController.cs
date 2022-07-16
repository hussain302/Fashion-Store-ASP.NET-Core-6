using FashionStore.Mappers.ProductMappers;
using FashionStore.Model.Models;
using FashionStore.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FashionStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository services;
        private readonly ICategoryRepository services1;
        private readonly ITypeRepository service2;
        private readonly IWebHostEnvironment web;

        public ProductController(IProductRepository services,
            ICategoryRepository service1,
            ITypeRepository service2, IWebHostEnvironment web)
        {
            this.services = services;
            this.services1 = service1;
            this.service2 = service2;
            this.web = web;
        }

        public IActionResult Manage()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if (ViewBag.Role != null && ViewBag.Role == "Admin")
            {
                var model = services.GetProducts().Select(x => x.ConvertToWebModel()).ToList();
                return View(model);
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
                ViewBag.Category = services1.GetCategories().Select(x => x.ConvertToWebModel());
                ViewBag.Type = service2.GetTypes().Select(x => x.ConvertToWebModel());
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        [HttpPost]
        public IActionResult Create(ProductModel model)
        {

            if (model.PhotoFile != null)
            {
                string folder = "Images/Products/";
                folder += model.PhotoFile.FileName;

                model.ImageModelURL = "/" + folder;
                string serverfolder = Path.Combine(web.WebRootPath, folder);
                model.PhotoFile.CopyTo(new FileStream(serverfolder, FileMode.Create)); ;
            }

            services.AddProduct(model.ConvertToDomainModel());
            return RedirectToAction("Manage");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if (ViewBag.Role != null && ViewBag.Role == "Admin")
            {
                ViewBag.Category = services1.GetCategories().Select(x => x.ConvertToWebModel());
                ViewBag.Type = service2.GetTypes().Select(x => x.ConvertToWebModel());
                var model = services.GetProduct(id).ConvertToWebModel();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
           
        }
        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            if (model.PhotoFile != null)
            {
                string folder = "Images/Products/";
                folder += model.PhotoFile.FileName;

                model.ImageModelURL = "/" + folder;
                string serverfolder = Path.Combine(web.WebRootPath, folder);
                model.PhotoFile.CopyTo(new FileStream(serverfolder, FileMode.Create)); ;
            }

            services.UpdateProduct(model.ConvertToDomainModel());
            return RedirectToAction("Manage");
        }
        public IActionResult Delete(int id)
        {
            
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if (ViewBag.Role != null && ViewBag.Role == "Admin")
            {
                var model = services.GetProduct(id).ConvertToWebModel();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        [HttpPost]
        public IActionResult Delete(ProductModel model)
        {
            services.DeleteProduct(model.Id);
            return RedirectToAction("Manage");
        }

    }
}
