using System.Collections.Generic;
using System.Threading.Tasks;
using WahlbergUr.Models;

namespace WahlbergUr.Business
{
    public interface IProductHandler
    {
        Task<Product> GetProduct(int productId);
        Task<bool> AddProduct(Product product);
        Task<List<Product>> ShowProducts();
    }
}
