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

        public async Task<bool> DeleteUser(User user)
        {
           
            using (var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey))
            {
                if (user == null)
                {
                    return false;
                }
                else
                {
                    await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, IdentityUserCollection, user.DatabaseId));
                    
                    return true;
                }
            }
        }

        public Task<User> GetUser(User user)
        {
            using (var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey))
            {
                var userCollection = client.CreateDocumentQuery<User>(UriFactory.CreateDocumentCollectionUri(DatabaseId, IdentityUserCollection));
                var foundUser = userCollection.AsEnumerable().FirstOrDefault((dBUser) => dBUser.UserName== user.UserName);
                return Task.FromResult<User>(foundUser);
            }
        }
    }
    }

