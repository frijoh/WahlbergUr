using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WahlbergUr.Business;
using WahlbergUr.Models;

namespace WahlbergUr.Controllers
{
    
    public class AdminController : Controller
    {
        private IProductHandler productHandler;

        public AdminController(IProductHandler productHandler)
        {
            this.productHandler = productHandler;

        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        // TODO not finished added so i could use objects in db, call from adminpanel
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var addProduct = await productHandler.AddProduct(product);
                if (addProduct)
                {
                    //uppdate showProducts
                    await TryUpdateModelAsync(product);
                    return RedirectToAction("ShowProducts", "Products", new { id = product.ProductId });
                }
                else{
                    ModelState.AddModelError("ProductId", "Something went wrong");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // add button 

            var deletedProduct = await productHandler.DeleteProduct(id);
            if (deletedProduct)
            {
                // update productlist
            }
            return View();
        }
    }
}