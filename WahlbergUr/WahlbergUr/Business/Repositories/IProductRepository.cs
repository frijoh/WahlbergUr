using System.Threading.Tasks;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(Product product);
        Task<bool> AddProduct(int id);
        void DeleteProduct();
        void UpdateProduct();
    }
}
