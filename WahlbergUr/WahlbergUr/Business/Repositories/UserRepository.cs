using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string DatabaseId = "WahlbergUr";
        private string IdentityUserCollection = "IdentityUserCollection";
        private readonly string EndPointURL = "https://localhost:8081";
        private readonly string AuthorizationKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";


        public Task<IEnumerable<User>> GetUsers()
        {
            return Task.Run(() =>
            {
                var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey);
                var users = client.CreateDocumentQuery<User>(
                    UriFactory.CreateDocumentCollectionUri(
                        DatabaseId, IdentityUserCollection)).AsEnumerable();
                return users;
            });
        }

        //public async Task<User> LogInUser(User logInUser)
        //{
        //    using (var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey))
        //    {
        //        var userCollection = client.CreateDocumentQuery<User>(UriFactory.CreateDocumentCollectionUri(DatabaseId, UserCollectionId));
        //        //var loggedInUser = userCollection.AsEnumerable().FirstOrDefault((user) => user.UserName == logInUser.UserName 
        //        //&& user.Password == logInUser.Password);

        //        //return await Task.FromResult<User>(loggedInUser);
        //        return null;
        //    }
        //}

        //public async Task<bool> RegisterUser(User newUser)
        //{
        //    using (var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey))
        //    {
        //        // check if user exist in db
        //        var userCollection = client.CreateDocumentQuery<User>(UriFactory.CreateDocumentCollectionUri(DatabaseId, UserCollectionId));
        //        var userExist = userCollection.AsEnumerable().Any((user) => user.UserName == newUser.UserName);

        //        if (!userExist)
        //        {
        //            // create user
        //            var result = await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, UserCollectionId), newUser);
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
    }
    }

