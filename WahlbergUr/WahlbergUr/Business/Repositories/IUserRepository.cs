using System.Threading.Tasks;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Repositories
{
    public interface IUserRepository
    {
        Task<bool> RegisterUser(User user);
        Task<bool> LogInUser(User user);
    }
}
