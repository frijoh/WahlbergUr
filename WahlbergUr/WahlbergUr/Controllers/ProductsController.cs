using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WahlbergUr.Business;

namespace WahlbergUr.Controllers
{
    public class ProductsController : Controller
    {
        private IProductHandler productHandler;

        public ProductsController(IProductHandler productHandler)
        {
            this.productHandler = productHandler;
        }

        public async Task<IActionResult> ShowProducts()
        {
            var productList = await productHandler.ShowProducts();
            return View(productList);
        }

        public async Task<IActionResult> ShowProduct(int id)
        {
            var foundProduct = await productHandler.GetProduct(id);
            ViewData["Product"] = foundProduct;
            return View();
        }
    }
}