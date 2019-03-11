﻿using Microsoft.Azure.Documents.Client;
using System;
using System.Linq;
using System.Threading.Tasks;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Repositories
{
    public class UserRepository : IUserRepository
    {
        private string DatabaseId = "WahlbergUr";
        private string UserCollectionId = "UserCollection";
        private string EndPointURL = "https://localhost:8081";
        private string AuthorizationKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        public Task<bool> LogInUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUser(User newUser)
        {
            using (var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey))
            {
                // check if product exist in db
                var userCollection = client.CreateDocumentQuery<User>(UriFactory.CreateDocumentCollectionUri(DatabaseId, UserCollectionId));
                var userExist = userCollection.AsEnumerable().Any((user) => user.UserName == newUser.UserName);

                if (!userExist)
                {
                    // create user
                    var result = await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, UserCollectionId), newUser);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
