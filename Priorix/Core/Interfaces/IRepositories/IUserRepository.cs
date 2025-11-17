using System.Collections.Generic;
using Priorix.Core.Entities;

namespace Priorix.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUserByEmail(string email);
        User FindById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        bool UserExists(int id);
    }
}
