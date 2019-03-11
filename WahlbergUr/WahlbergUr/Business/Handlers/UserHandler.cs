﻿using System.Threading.Tasks;
using WahlbergUr.Business.Repositories;
using WahlbergUr.Models;

namespace WahlbergUr.Business.Handlers
{
    public class UserHandler : IUserHandler
    {
        public IUserRepository userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> LogInUser(User user)
        {
            var loginUser = await userRepository.LogInUser(user);

            if (loginUser == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> RegisterUser(User user)
        {
            var registerUser = await userRepository.RegisterUser(user);

            if (registerUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}