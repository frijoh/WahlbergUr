using System;
using System.Threading.Tasks;
using WahlbergUr.Business.Repositories;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Handlers
{
    public class ShopHandler : IShopHandler
    {
        private IShopRepository shopRepository;

        public ShopHandler(IShopRepository shopRepository)
        {
            this.shopRepository = shopRepository;
        }

        public Task<bool> AddCustomerInformation(Shop shop)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddShopInformation(Shop shop)
        {
            var addShopInformation = await shopRepository.AddShopInformation(shop);
            if (addShopInformation)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Shop> GetShopInformation(Shop shop)
        {
            var ShopInformation = await shopRepository.GetShopInformation(shop);
            return ShopInformation;
        }

        public Task<Shop> UpdateCustomerInformation(Shop shop)
        {
            throw new NotImplementedException();
        }

        public async Task<Shop> UpdateShopInformation(Shop shop)
        {
            var updatedShopInformation = await shopRepository.UpdateShopInformation(shop);
            return updatedShopInformation;
        }
    }
}
