using FashionStore.Mappers.OrderMappers;
using FashionStore.Model.Models;
using FashionStore.Repositories.IRepositories;
using FashionStore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FashionStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        
        private readonly IProductRepository services1;
        private readonly IOrderRepository orderService;

        public CartController(IProductRepository services1 , IOrderRepository orderService)
        {
            this.services1 = services1;
            this.orderService = orderService;
        }


        public IActionResult OrderConfirm()
        {
            return RedirectToAction("Orders");
        }


        [HttpGet]
        public IActionResult Checkout()
        {

            ViewBag.Name = HttpContext.Session.GetString("Name");
            //ViewBag.Role = HttpContext.Session.GetString("Role");

            if (ViewBag.Name != null)
            {
                ModelHelperCart helperCart = new ModelHelperCart();
                var models = helperCart.GetCartItems();
                return View(models);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }            
        }
        [HttpGet]
        public IActionResult ConfirmOrder()
        {

            ModelHelperCart helper = new ModelHelperCart();
            var OrderItems =  helper.GetCartItems();
        
            foreach (var order in OrderItems)
            {
                order.UserName = HttpContext.Session.GetString("Name");
                order.Phone = HttpContext.Session.GetString("Phone");

                orderService.AddOrder(order.ConvertToDomainModel());
            }

            helper.ClearCartItems();
            ViewBag.OrderConfirm = "Order has been submitted successfully you will be contacted soon for futher details!";
            return RedirectToAction("Checkout");
        }

        public IActionResult Add(ProductModel productModel)
        {
            var findProduct = services1.GetProduct(productModel.Id);
            if(findProduct != null)
            {
                ModelHelperCart helper = new ModelHelperCart();
                helper.AddCartItem(new CartItemModel
                {
                    ItemId = findProduct.Id,
                    ItemPrice = findProduct.Price,
                    Title = findProduct.Name
                });
            }
            return RedirectToAction("Homepage", "Customer");
        }

        public IActionResult Delete(int id)
        {
            ModelHelperCart helper = new ModelHelperCart();
            helper.RemoveCartItem(id);
            return RedirectToAction("Checkout");
        }

    }
}
