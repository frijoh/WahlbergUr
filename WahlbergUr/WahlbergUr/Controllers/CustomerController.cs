using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WahlbergUr.Business.Handlers;
using WahlbergUr.Models;

namespace WahlbergUr.Controllers
{
    public class CustomerController : Controller
    {
        public IUserHandler userHandler;

        public object FormsAuthentication { get; private set; }

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
            if (ModelState.IsValid)
            {
                var registerUser = await userHandler.RegisterUser(user);
                if (registerUser)
                {
                    return RedirectToAction("LogIn", "Customer");
                }
                else
                {
                    ModelState.AddModelError("UserName", "Username Already Exist");
                }
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInUser logInUser)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = logInUser.UserName,
                    Password = logInUser.Password,
                };
                
                var loggedInUser = await userHandler.LogInUser(user);
                if (loggedInUser == null)
                {
                    ModelState.AddModelError("UserName", "Username or Password Incorrect!");
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    if(loggedInUser.UserName == "Eva")
                    {
                        // redirect to admin page, TODO, auth
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        // TODO redirect to private page
                        return RedirectToAction("Index", "Customer");
                    }
                }
            }
            return View(logInUser);
        }
    }
}