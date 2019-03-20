using System.Collections.Generic;
using System.Threading.Tasks;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<bool> DeleteUser(User user);
        Task<User> GetUser(User user);
    }
}
