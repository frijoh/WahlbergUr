using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WahlbergUr.Business.Repositories;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Handlers
{
    public class UserHandler : IUserHandler
    {
        private IUserRepository userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> DeleteUser(User user)
        {
            var deletedUser = await userRepository.DeleteUser(user);

            if (deletedUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User> GetUser(string UserName)
        {
            var user = new User() { UserName = UserName};
            var foundUser = await userRepository.GetUser(user);
            return foundUser;
        }

        public async Task<List<EditUser>> GetUsers()
        {
            var editUsers = new List<EditUser>();
            var users = await userRepository.GetUsers();
            foreach (var user in users)
            {
                editUsers.Add(new EditUser()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                });
            }     
            return editUsers;
        }
    }
}
