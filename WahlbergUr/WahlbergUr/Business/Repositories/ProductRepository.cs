using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private string DatabaseId = "WahlbergUr";
        private string ProductCollectionId = "ProductCollection";
        private string EndPointURL = "https://localhost:8081";
        private string AuthorizationKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        public async Task<bool> AddProduct(Product newProduct)
        {
            using (var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey))
            {
                // check if product exist in db
                var productCollection = client.CreateDocumentQuery<Product>(UriFactory.CreateDocumentCollectionUri(DatabaseId, ProductCollectionId));
                var productExist = productCollection.AsEnumerable().Any((product) => product.ProductId == newProduct.ProductId);

                if (!productExist)
                {
                    // create product
                    var result = await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, ProductCollectionId), newProduct);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<Product> UpdateProduct(Product updateProduct)
        {
            using (var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey))
            {
                var doc = client.CreateDocumentQuery<Product>(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, ProductCollectionId))
                            .Where(x => x.ProductId == updateProduct.ProductId)
                            .AsEnumerable()
                            .SingleOrDefault();

                doc.ProductId = updateProduct.ProductId;
                doc.ProductName = updateProduct.ProductName;
                doc.ProductInformation = updateProduct.ProductInformation;
                doc.ProductPrice = updateProduct.ProductPrice;
                doc.ProductUrl = updateProduct.ProductUrl;

                var result = await client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, ProductCollectionId), doc);// (UriFactory.CreateDocumentCollectionUri(DatabaseId, ProductCollectionId), updateProduct);
                return doc;
            }
        }

        public Task<Product> GetProduct(Product findProduct)
        {
            using (var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey))
            {
                var productCollection = client.CreateDocumentQuery<Product>(UriFactory.CreateDocumentCollectionUri(DatabaseId, ProductCollectionId));
                var foundProduct = productCollection.AsEnumerable().FirstOrDefault((product) => product.ProductId == findProduct.ProductId);
                return Task.FromResult<Product>(foundProduct);
            }
        }

        public Task<List<Product>> ShowProducts()
        {
            using (var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey))
            {
                var productCollection = client.CreateDocumentQuery<Product>(UriFactory.CreateDocumentCollectionUri(DatabaseId, ProductCollectionId)).ToList();
                return Task.FromResult<List<Product>>(productCollection);
            }
        }

        public async Task<bool> DeleteProduct(Product productToDelete)
        {
            using (var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey))
            {
                //var productExist = client.CreateDocumentQuery<Product>(UriFactory.CreateDocumentCollectionUri(DatabaseId, ProductCollectionId),
                //new SqlQuerySpec(string.Format("SELECT * FROM product WHERE product.ProductId = '{0}'", productToDelete.ProductId))).AsEnumerable().FirstOrDefault();

                //var productCollection = client.CreateDocumentQuery<Product>(UriFactory.CreateDocumentCollectionUri(DatabaseId, ProductCollectionId));
                //var productExist = productCollection.AsEnumerable().Any((product) => product.ProductId == productToDelete.ProductId);
                var productCollection = client.CreateDocumentQuery<Product>(UriFactory.CreateDocumentCollectionUri(DatabaseId, ProductCollectionId)).ToList();
                foreach (var product in productCollection)
                {
                    if (product.ProductId == productToDelete.ProductId)
                    {
                        //Uri doc = UriFactory.CreateDocumentUri(DatabaseId, ProductCollectionId, product.ProductId.ToString());
                        //await client.DeleteDocumentAsync(doc);

                        await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, ProductCollectionId, product.ProductId.ToString()));
                        return true;
                    }

                }
                return false;

                //if (productExist == null)
                //{
                //    return false;
                //}
                //else
                //{

                //    await client.DeleteDocumentAsync(productExist.ToString());
                //    return true;
                //}


                //var productExist = await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, ProductCollectionId, productToDelete.ProductId.ToString()));

                //if (productExist != null)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
        }
    }
}

