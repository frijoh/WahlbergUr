using System.Threading.Tasks;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Repositories
{
    public interface IShopRepository
    {
        Task<bool> AddShopInformation(Shop shop);
        Task<Shop> UpdateShopInformation(Shop shop);
        Task<bool> AddCustomerInformation(Shop shop);
        Task<Shop> UpdateCustomerInformation(Shop shop);
        Task<Shop> GetShopInformation(Shop shop);
    }
}
