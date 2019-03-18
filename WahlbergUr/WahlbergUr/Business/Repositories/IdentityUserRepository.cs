using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Repositories
{
    public class IdentityUserRepository :
        IUserStore<User>,
        IUserPasswordStore<User>,
        IUserRoleStore<User>
    {
        private string DatabaseId = "WahlbergUr";
        private string IdentityUserCollection = "IdentityUserCollection";
        private string EndPointURL = "https://localhost:8081";
        private string AuthorizationKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                if (user.Roles == null)
                {
                    user.Roles = new List<string>();
                }
                user.Roles.Add(roleName);
            }, cancellationToken);
        }

        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                try
                {
                    var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey);
                    client.CreateDocumentAsync(
                        UriFactory.CreateDocumentCollectionUri(
                           DatabaseId,
                           IdentityUserCollection), user);
                    return IdentityResult.Success;
                }
                catch (Exception)
                {
                    return IdentityResult.Failed(new IdentityError()
                    {
                        Code = "",
                        Description = "",
                    });
                }
            }, cancellationToken);
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey);
                return client.CreateDocumentQuery<User>(
                   UriFactory.CreateDocumentCollectionUri(
                       DatabaseId,
                       IdentityUserCollection))
                       .AsEnumerable()
                       .Where(identityUser => identityUser.Id == userId)
                       .FirstOrDefault();
            }, cancellationToken);
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey);
                return client.CreateDocumentQuery<User>(
                   UriFactory.CreateDocumentCollectionUri(
                       DatabaseId,
                       IdentityUserCollection))
                       .AsEnumerable()
                       .Where(identityUser => identityUser.NormalizedUserName == normalizedUserName)
                       .FirstOrDefault();
            }, cancellationToken);
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return user.NormalizedUserName;
            }, cancellationToken);
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return user.PasswordHash;
            }, cancellationToken);
        }

        public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return user.Roles;
            }, cancellationToken);
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return user.Id;
            }, cancellationToken);
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return user.UserName;
            }, cancellationToken);
        }

        public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return user.Roles != null ? user.Roles.Contains(roleName) : false;
            }, cancellationToken);
        }

        public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                user.NormalizedUserName = normalizedName;
            }, cancellationToken);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                user.PasswordHash = passwordHash;
            }, cancellationToken);
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                user.UserName = userName;
            }, cancellationToken);
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(user.DatabaseId))
                    {
                        var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey);
                        var databaseUser = client.CreateDocumentQuery<User>(
                           UriFactory.CreateDocumentCollectionUri(
                               DatabaseId,
                               IdentityUserCollection))
                               .AsEnumerable()
                               .Where(identityUser => identityUser.Id == user.Id)
                               .FirstOrDefault();

                        user.DatabaseId = databaseUser.DatabaseId;
                        client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(
                               DatabaseId,
                               IdentityUserCollection), user);
                    }
                    else
                    {
                        var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey);
                        client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(
                               DatabaseId,
                               IdentityUserCollection), user);
                    }
                    return IdentityResult.Success;
                }
                catch (Exception e)
                {
                    return IdentityResult.Failed(new IdentityError()
                    {
                        Code = "",
                        Description = ""
                    });
                }
            }, cancellationToken);
        }
    }
}
