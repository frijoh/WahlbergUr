using Microsoft.AspNetCore.Mvc;
using WahlbergUr.Business.Handlers;

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
    }
}