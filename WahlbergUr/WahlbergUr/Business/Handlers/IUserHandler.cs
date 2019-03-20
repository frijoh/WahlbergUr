using System.Collections.Generic;
using System.Threading.Tasks;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Handlers
{
    public interface IUserHandler
    {
        Task<List<EditUser>> GetUsers();
        Task<bool> DeleteUser(User user);
        Task<User> GetUser(string UserName);
    }
}
