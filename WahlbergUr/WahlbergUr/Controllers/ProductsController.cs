using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WahlbergUr.Business;
using WahlbergUr.Models;

namespace WahlbergUr.Controllers
{
    public class ProductsController : Controller
    {
        private IProductHandler productHandler;

        public ProductsController(IProductHandler productHandler)
        {
            this.productHandler = productHandler;
            
        }

        //public IActionResult ShowProducts()
        //{
        //    var productList = new List<Product>
        //    {
        //        new Product() { ProductId = 1, ProductName = "Cartier", ProductPrice = 2000, ProductInformation = "Fantastic", ProductUrl = "~/images/cartiertest.jpg" } ,
        //        new Product() { ProductId = 2, ProductName = "Rolex", ProductPrice = 3000, ProductInformation = "Best Rolex", ProductUrl = "~/images/rolextest.jpg" } ,
        //        new Product() { ProductId = 3, ProductName = "Seiko", ProductPrice = 4000, ProductInformation = "Super watch", ProductUrl = "~/images/seikotest.jpg" } ,
        //        new Product() { ProductId = 4, ProductName = "Swiss Military", ProductPrice = 3500, ProductInformation = "Best swiss watch", ProductUrl = "~/images/swisstest.jpg" } ,
        //        new Product() { ProductId = 5, ProductName = "Emporio Armani Classic", ProductPrice = 200, ProductInformation = "Nice gold watch", ProductUrl = "~/images/emporio-armani.jpg" }
        //    };

        //    return View(productList);
        //}

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

        // TODO not finished added so i could use objects in db, call from adminpanel
        public async Task<IActionResult> AddProduct(Product product)
        {
            // add button adminpanel
            var addProduct = await productHandler.AddProduct(product);

            // if true, uppdatera showProducts och skriv ut på sidan
            // if false, hantera

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // add button 

            var deletedProduct = await productHandler.DeleteProduct(id);
            if (deletedProduct)
            {
                return RedirectToAction("ShowProducts");
            }
            return View();
        }
    }
}