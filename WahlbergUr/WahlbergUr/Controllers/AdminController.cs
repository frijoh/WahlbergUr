using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WahlbergUr.Business;
using WahlbergUr.Business.Handlers;
using WahlbergUr.Models;

namespace WahlbergUr.Controllers
{
    [Authorize(Policy = "Administrator")]
    public class AdminController : Controller
    {
        private IProductHandler productHandler;
        private IShopHandler shopHandler;

        public AdminController(IProductHandler productHandler, IShopHandler shopHandler)
        {
            this.productHandler = productHandler;
            this.shopHandler = shopHandler;
           
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


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var addProduct = await productHandler.AddProduct(product);
                if (addProduct)
                {
                    //uppdate Product
                    await TryUpdateModelAsync(product);
                    return RedirectToAction("ShowProducts", "Products", new { id = product.ProductId });
                }
                else{
                    ModelState.AddModelError("ProductId", "Something went wrong");
                }
            }
            return View();
        }

        public async Task<IActionResult> EditProducts()
        {
            var productList = await productHandler.ShowProducts();
            return View(productList);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var foundProduct = await productHandler.GetProduct(id);
            ViewData["Product"] = foundProduct;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var updatedProduct = await productHandler.UpdateProduct(product);
                if(updatedProduct == null)
                {
                    ModelState.AddModelError("ProductId", "Something went wrong");
                }
                else
                {
                    //uppdate Product
                    await TryUpdateModelAsync(updatedProduct);
                    return RedirectToAction("ShowProducts", "Products", new { id = updatedProduct.ProductId });
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await productHandler.GetProduct(id);
            var deletedProduct = await productHandler.DeleteProduct(product);

            if (deletedProduct)
            {
                //uppdate Product
                return RedirectToAction("ShowProducts", "Products");
            }
            else
            {
                return View("NotFound");
            }
        }


        public IActionResult EditCustomerInformation()
        {
            return View();
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddCustomerInformation()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditShopInformation()
        {
            var shop = new Shop();
            var shopInformation = await shopHandler.GetShopInformation(shop);
            ViewData["Information"] = shopInformation;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditShopInformation(Shop shop)
        {
            if (ModelState.IsValid)
            {
                var shopInformation = await shopHandler.UpdateShopInformation(shop);
                if (shopInformation == null)
                {
                    ModelState.AddModelError("FromDay", "Something went wrong");
                }
                else
                {
                    //uppdate Shop
                    await TryUpdateModelAsync(shopInformation);
                    return RedirectToAction(nameof(AdminController.Index), "Admin");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddShopInformation()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddShopInformation(Shop shop)
        {

            if (ModelState.IsValid)
            {
                var addShopInformation = await shopHandler.AddShopInformation(shop);
                if (addShopInformation)
                {
                    //uppdate Product
                    await TryUpdateModelAsync(shop);
                }
                else
                {
                    ModelState.AddModelError("FromDay", "Something went wrong");
                }
            }
            return View();
        }
    }
}