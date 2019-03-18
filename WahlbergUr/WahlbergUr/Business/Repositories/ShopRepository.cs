using Microsoft.Azure.Documents.Client;
using System;
using System.Linq;
using System.Threading.Tasks;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private string DatabaseId = "WahlbergUr";
        private string ShopCollectionId = "ShopCollection";
        private string EndPointURL = "https://localhost:8081";
        private string AuthorizationKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";


        public Task<bool> AddCustomerInformation(Shop shop)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddShopInformation(Shop shop)
        {
            using (var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey))
            {
                // check if product exist in db
                var shopCollection = client.CreateDocumentQuery<Shop>(UriFactory.CreateDocumentCollectionUri(DatabaseId, ShopCollectionId));
                var shopExist = shopCollection.AsEnumerable().Any((shopItem) => shopItem.id == shop.id);

                if (!shopExist)
                {
                    // create shopinformation
                    var result = await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, ShopCollectionId), shop);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Task<Shop> GetShopInformation(Shop shop)
        {
            using (var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey))
            {
                var shopCollection = client.CreateDocumentQuery<Shop>(UriFactory.CreateDocumentCollectionUri(DatabaseId, ShopCollectionId));
                shop = shopCollection.AsEnumerable().FirstOrDefault();
                return Task.FromResult<Shop>(shop);
            }
        }

        public Task<Shop> UpdateCustomerInformation(Shop shop)
        {
            throw new NotImplementedException();
        }

        public async Task<Shop> UpdateShopInformation(Shop shop)
        {
            using (var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey))
            {
                var shopItem = client.CreateDocumentQuery<Shop>(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, ShopCollectionId))
                            .AsEnumerable().FirstOrDefault();

                shopItem.FromDay = shop.FromDay;
                shopItem.ToDay = shop.ToDay;
                shopItem.Weekend = shop.Weekend;
                shopItem.OpeningHours = shop.OpeningHours;
                shopItem.ClosingHours = shop.ClosingHours;
                shopItem.IsClosed = shop.IsClosed;
                shopItem.Address = shop.Address;
                shopItem.PostalCode = shop.PostalCode;
                shopItem.City = shop.City;
                shopItem.PhoneNumber = shop.PhoneNumber;
                shopItem.ShopInformation = shop.ShopInformation;

                var result = await client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, ShopCollectionId), shopItem);
                return shopItem;
            }
        }
    }
}
