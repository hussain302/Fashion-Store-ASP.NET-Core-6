using FashionStore.Repositories.IRepositories;
using FashionStore.Model.Models;
using Microsoft.AspNetCore.Mvc;
using FashionStore.Mappers.UserMappers;

namespace FashionStore.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository context;
        public UserController(IUserRepository context)
        {
            this.context = context;
        }

        public IActionResult Manage()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");

            if (ViewBag.Role != null && ViewBag.Role == "Admin")
            {
               var users = context.GetUsers()
                    .Select(x => x.ConvertToWebModel())
                    .ToList();
                return View(users);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            model.RoleId = 2;
            context.AddUser(model.ConvertToDomainModel());
            return RedirectToAction("Login", "User");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            var response = context.VerifyUser(model.ConvertToDomainModel());

            if (response != null)
            {

                HttpContext.Session.SetString("Name", response.FirstName);
                HttpContext.Session.SetString("Role", response.Role.Name);
                HttpContext.Session.SetString("Phone", response.Phone);

                if (response.RoleId == 2) 
                {
                    return RedirectToAction("Homepage", "Customer"); 
                }
                else if (response.RoleId == 1) 
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "User");
                }            
            }
            else
            {
                ViewBag.ErrorMessage = "Enter correct credentials!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Homepage", "Customer");
        }
    }
}
