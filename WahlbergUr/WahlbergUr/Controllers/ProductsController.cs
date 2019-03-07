﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult ShowProducts()
        {
            var productList = new List<Product>
            {
                new Product() { ProductId = 1, ProductName = "Cartier", ProductPrice = 2000, ProductInformation = "Fantastic", ProductUrl = "~/images/cartiertest.jpg" } ,
                new Product() { ProductId = 2, ProductName = "Rolex", ProductPrice = 3000, ProductInformation = "Best Rolex", ProductUrl = "~/images/rolextest.jpg" } ,
                new Product() { ProductId = 3, ProductName = "Seiko", ProductPrice = 4000, ProductInformation = "Super watch", ProductUrl = "~/images/seikotest.jpg" } ,
                new Product() { ProductId = 4, ProductName = "Swiss Military", ProductPrice = 3500, ProductInformation = "Best wiss watch", ProductUrl = "~/images/swisstest.jpg" } ,
                new Product() { ProductId = 5, ProductName = "Emporio Armani Classic", ProductPrice = 200, ProductInformation = "Nice gold watch", ProductUrl = "~/images/emporio-armani.jpg" }
            };

            return View(productList);
        }

        public async Task<IActionResult> ShowProduct(int id)
        {
            var foundProduct = await productHandler.GetProduct(id);

            ViewData["Product"] = new Product()
            {
               ProductId = foundProduct.ProductId,
               ProductInformation = foundProduct.ProductInformation,
               ProductName = foundProduct.ProductName,
               ProductPrice = foundProduct.ProductPrice,
               ProductUrl = foundProduct.ProductUrl,
            };

            return View();
        }

        // TODO not finished added so i could use objects in db, call from adminpanel
        public async Task<IActionResult> AddProduct(Product product)
        {
            var addProduct = await productHandler.AddProduct(product);

            // if true, uppdatera showProducts och skriv ut på sidan
            // if false, hantera

            return View();
        }
    }
}