﻿using System.Threading.Tasks;
using WahlbergUr.Business.Repositories;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Handlers
{
    public class ProductHandler : IProductHandler
    {
        private IProductRepository productRepository;

        public ProductHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<bool> AddProduct(Product product)
        {
            var addProduct = await productRepository.AddProduct(product);
            if (addProduct != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Product> GetProduct(int productId)
        {
            var product1 = new Product() { ProductId = productId };
            var foundProduct = await productRepository.GetProduct(product1);
            
            return foundProduct;
        }
    }
}
