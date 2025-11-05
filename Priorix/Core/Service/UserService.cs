using System.Collections.Generic;
using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Core.Interfaces.Services;

namespace Priorix.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetUsers() => _userRepository.GetUsers();

        public User GetUserByEmail(string email) => _userRepository.GetUserByEmail(email);

        public User FindById(int id) => _userRepository.FindById(id);

        public void AddUser(User user) => _userRepository.AddUser(user);

        public void UpdateUser(User user) => _userRepository.UpdateUser(user);

        public void DeleteUser(int id) => _userRepository.DeleteUser(id);

        public bool UserExists(int id) => _userRepository.UserExists(id);
    }
}
