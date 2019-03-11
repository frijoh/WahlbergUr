using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WahlbergUr.Business.Handlers;
using WahlbergUr.Models;

namespace WahlbergUr.Controllers
{
    public class CustomerController : Controller
    {
        public IUserHandler userHandler;

        public CustomerController(IUserHandler userHandler)
        {
            this.userHandler = userHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            // TODO handle reg. user if something
            var registerUser = await userHandler.RegisterUser(user);
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }
    }
}