﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WahlbergUr.Business;
using WahlbergUr.Models;

namespace WahlbergUr.Controllers
{
    [Authorize(Policy = "Administrator")]
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
    }
}