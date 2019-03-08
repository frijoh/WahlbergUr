using System.Collections.Generic;
using System.Threading.Tasks;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(Product product);
        Task<bool> AddProduct(Product product);
        void UpdateProduct();
        Task<List<Product>> ShowProducts();
        Task<bool> DeleteProduct(Product product);
    }
}
