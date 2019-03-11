using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WahlbergUr
{
    public class DatabaseConfiguration
    {
        private string DatabaseId = "WahlbergUr";
        private string ProductCollectionId = "ProductCollection";
        private string UserCollectionId = "UserCollection";
        private string EndPointURL = "https://localhost:8081";
        private string AuthorizationKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private DocumentCollection userCollection;

        public async void Configure()
        {
            var client = new DocumentClient(new System.Uri(EndPointURL), AuthorizationKey);
            var database = await client.CreateDatabaseIfNotExistsAsync(new Microsoft.Azure.Documents.Database { Id = DatabaseId });
            var productCollection = await client.CreateDocumentCollectionIfNotExistsAsync(database.Resource.SelfLink, new DocumentCollection { Id = ProductCollectionId });

            userCollection = await client.CreateDocumentCollectionIfNotExistsAsync(database.Resource.SelfLink, new DocumentCollection { Id = UserCollectionId });
        }
    }
}
