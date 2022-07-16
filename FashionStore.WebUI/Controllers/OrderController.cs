using FashionStore.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FashionStore.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository service;

        public OrderController(IOrderRepository service)
        {
            this.service = service;
        }

        public IActionResult Manage()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");

            if (ViewBag.Role != null && ViewBag.Role == "Admin")
            { 
                return View(service.GetOrders());
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            service.RemoveOrder(id);
            return RedirectToAction("Manage");
        }
        [HttpGet]
        public IActionResult Approve(int id)
        {
            service.ApproveOrder(id);
            return RedirectToAction("Manage");
        }
        
        [HttpGet]
        public IActionResult Delivered(int id)
        {
            service.DeliveredOrder(id);
            return RedirectToAction("Manage");
        }


    }
}
