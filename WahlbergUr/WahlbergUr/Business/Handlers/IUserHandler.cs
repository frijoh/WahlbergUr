using System.Threading.Tasks;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Handlers
{
    public interface IUserHandler
    {
        Task<bool> RegisterUser(User user);
        Task<bool> LogInUser(User user);
    }
}
