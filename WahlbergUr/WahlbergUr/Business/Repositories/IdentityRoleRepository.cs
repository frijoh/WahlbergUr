using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Documents.Client;
using System;
using System.Threading;
using System.Threading.Tasks;
using WahlbergUr.Models;
using System.Linq;

namespace WahlbergUr.Business.Repositories
{
    public class IdentityRoleRepository : IRoleStore<IdentityRole>
    {
        private string DatabaseId = "WahlbergUr";
        private string IdentityRoleCollection = "IdentityRoleCollection";
        private string EndPointURL = "https://localhost:8081";
        private string AuthorizationKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        public Task<IdentityResult> CreateAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                try
                {
                    var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey);
                    client.CreateDocumentAsync(
                        UriFactory.CreateDocumentCollectionUri(
                           DatabaseId,
                           IdentityRoleCollection), role);
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

        public Task<IdentityResult> DeleteAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public Task<IdentityRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var client = new DocumentClient(new Uri(EndPointURL), AuthorizationKey);
                return client.CreateDocumentQuery<IdentityRole>(
                   UriFactory.CreateDocumentCollectionUri(
                       DatabaseId,
                       IdentityRoleCollection))
                       .AsEnumerable()
                       .Where(identityRole => identityRole.NormalizedName == normalizedRoleName)
                       .FirstOrDefault();
            }, cancellationToken);
        }

        public Task<string> GetNormalizedRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return role.NormalizedName;
            }, cancellationToken);
        }

        public Task<string> GetRoleIdAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return role.Id;
            }, cancellationToken);
        }

        public Task<string> GetRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return role.Name;
            }, cancellationToken);
        }

        public Task SetNormalizedRoleNameAsync(IdentityRole role, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                role.NormalizedName = normalizedName;
            }, cancellationToken);
        }

        public Task SetRoleNameAsync(IdentityRole role, string roleName, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                role.Name = roleName;
            }, cancellationToken);
        }

        public Task<IdentityResult> UpdateAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
