using FashionStore.Mappers.OrderMappers;
using FashionStore.Model.Models;
using FashionStore.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FashionStore.WebUI.Controllers
{
    public class OrderStatusController : Controller
    {
        private readonly IOrderStatusRepository services;

        public OrderStatusController(IOrderStatusRepository services)
        {
            this.services = services;
        }
        
        public IActionResult Manage()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if (ViewBag.Role != null && ViewBag.Role == "Admin")
            {
                var models = services.GetOrderStatuss().Select(x => x.ConvertToWebModel());
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
        public IActionResult Create(OrderStatusModel model)
        {
            services.AddOrderStatus(model.ConvertToDomainModel());
            return RedirectToAction("Manage");
        }
        public IActionResult Edit(int id)
        {
           
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if (ViewBag.Role != null && ViewBag.Role == "Admin")
            {
                var find = services.GetOrderStatus(id).ConvertToWebModel();
                return View(find);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpPost]
        public IActionResult Edit(OrderStatusModel model)
        {

            services.UpdateOrderStatus(model.ConvertToDomainModel());
            return RedirectToAction("Manage");
        }
        public IActionResult Delete(int id)
        {
           
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if (ViewBag.Role != null && ViewBag.Role == "Admin")
            {
                var find = services.GetOrderStatus(id).ConvertToWebModel();
                return View(find);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpPost]
        public IActionResult Delete(OrderStatusModel model)
        {
            services.DeleteOrderStatus(model.Id);
            return RedirectToAction("Manage");
        }

    }
}
