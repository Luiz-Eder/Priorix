using System.Collections.Generic;
using System.Linq;
using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Data.Context;
using TaskEntity = Priorix.Core.Entities.Task;

namespace Priorix.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _db;

        public UserRepository(DataContext db)
        {
            _db = db;
        }

        public List<User> GetUsers() => [.. _db.Users];

        public User GetUserByEmail(string email)
        {
            return _db.Users.FirstOrDefault(u => u.Email == email);
        }

        public User FindById(int id)
        {
            return _db.Users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }

        public bool UserExists(int id) => _db.Users.Any(u => u.Id == id);
    }
}
