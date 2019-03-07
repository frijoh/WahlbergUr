using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Threading.Tasks;
using WahlbergUr.Models;
using System.Linq;

namespace WahlbergUr.Business.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private string DatabaseId = "WahlbergUr";
        private string ProductCollectionId = "ProductCollection";
        private string EndPointURL = "https://localhost:8081";
        private string AuthorizationKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";


        // Added to test get funktion 
        // TODO not finished, belongs to admin panel
        public async Task<bool> AddProduct(int id)
        {
            var product1 = new Product
            {
                ProductId = id,
                //ProductName = "Cartier",
                //ProductPrice = 2000,
                //ProductInformation = "Fantastic",
                //ProductUrl = "~/images/cartiertest.jpg"
            };

            using (var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey))
            {
                var productCollection = client.CreateDocumentQuery<Product>(UriFactory.CreateDocumentCollectionUri(DatabaseId, ProductCollectionId));
                var productExist = productCollection.AsEnumerable().Any((product) => product.ProductId == product1.ProductId);

                if (!productExist)
                {
                    // create product
                    var result = await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, ProductCollectionId), product1);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(Product product1)
        {
            using (var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey))
            {
                var productResult = new Product();
                var productCollection = client.CreateDocumentQuery<Product>(UriFactory.CreateDocumentCollectionUri(DatabaseId, ProductCollectionId));
                var foundProduct = productCollection.AsEnumerable().FirstOrDefault((product) => product.ProductId == product1.ProductId);
                productResult = foundProduct;
                return Task.FromResult<Product>(productResult);
            }
        }
    }
}

