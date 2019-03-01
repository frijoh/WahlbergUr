using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WahlbergUr.Models;

namespace WahlbergUr.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowProducts()
        {
            var productList = new List<Product>
            {
                new Product() { ProductId = 1, ProductName = "Cartier", ProductPrice = 2000, ProductInformation = "Fantastic", ProductUrl = "~/images/cartiertest.jpg" } ,
                new Product() { ProductId = 2, ProductName = "Rolex", ProductPrice = 3000, ProductInformation = "Best Rolex", ProductUrl = "~/images/rolextest.jpg" } ,
                new Product() { ProductId = 3, ProductName = "Seiko", ProductPrice = 4000, ProductInformation = "Super watch", ProductUrl = "~/images/seikotest.jpg" } ,
                new Product() { ProductId = 4, ProductName = "Swiss Military", ProductPrice = 3500, ProductInformation = "Best wiss watch", ProductUrl = "~/images/swisstest.jpg" } ,
            };

            return View(productList);
        }

        public IActionResult ShowProduct(int id)
        {
            var productList = new List<Product>
            {
                new Product() { ProductId = 1, ProductName = "Cartier", ProductPrice = 2000, ProductInformation = "Fantastic", ProductUrl = "~/images/cartiertest.jpg" } ,
                new Product() { ProductId = 2, ProductName = "Rolex", ProductPrice = 3000, ProductInformation = "Best Rolex", ProductUrl = "~/images/rolextest.jpg" } ,
                new Product() { ProductId = 3, ProductName = "Seiko", ProductPrice = 4000, ProductInformation = "Super watch", ProductUrl = "~/images/seikotest.jpg" } ,
                new Product() { ProductId = 4, ProductName = "Swiss Military", ProductPrice = 3500, ProductInformation = "Best wiss watch", ProductUrl = "~/images/swisstest.jpg" } ,
            };

            foreach(var product in productList)
            {
                if(product.ProductId == id)
                {
                    ViewData["Message"] = product;
                }
            }

            // hämta lämplig info för specifierat id nummer och skicka till vyn, db

            
            return View();
        }
    }
}