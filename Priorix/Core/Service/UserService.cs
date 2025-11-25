using System;
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

        public User GetUserByEmail(string email)
        {
            if (email == null || email == "")
                throw new Exception("Email inválido.");

            return _userRepository.GetUserByEmail(email);
        }

        public User FindById(int id)
        {
            if (id <= 0)
                throw new Exception("Id inválido.");

            var user = _userRepository.FindById(id);

            if (user == null)
                throw new Exception("Usuário não encontrado.");

            return user;
        }

        public void AddUser(User user)
        {
            if (user == null)
                throw new Exception("Usuário inválido.");

            if (user.Name == null || user.Name == "")
                throw new Exception("Nome obrigatório.");

            if (user.Email == null || user.Email == "")
                throw new Exception("Email obrigatório.");

            var existing = _userRepository.GetUserByEmail(user.Email);
            if (existing != null)
                throw new Exception("Já existe um usuário com este email.");

            _userRepository.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
                throw new Exception("Usuário inválido.");

            if (user.Id <= 0)
                throw new Exception("Id inválido.");

            if (!_userRepository.UserExists(user.Id))
                throw new Exception("Usuário não existe.");

            if (user.Name == null || user.Name == "")
                throw new Exception("Nome obrigatório.");

            if (user.Email == null || user.Email == "")
                throw new Exception("Email obrigatório.");

            var anotherUser = _userRepository.GetUserByEmail(user.Email);
            if (anotherUser != null && anotherUser.Id != user.Id)
                throw new Exception("Email já está sendo usado por outro usuário.");

            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            if (id <= 0)
                throw new Exception("Id inválido.");

            if (!_userRepository.UserExists(id))
                throw new Exception("Usuário não existe.");

            _userRepository.DeleteUser(id);
        }

        public bool UserExists(int id)
        {
            if (id <= 0)
                return false;

            return _userRepository.UserExists(id);
        }
    }
}
