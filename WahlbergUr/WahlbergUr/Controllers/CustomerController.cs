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

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(User user)
        {
            // TODO handle logged in user if something is true send to private customer view
            var loginUser = await userHandler.LogInUser(user);
            if (!loginUser)
            {
                // handle login problem
            }
            else
            {
                // User is logged in
            }

            return View();
        }
    }
}