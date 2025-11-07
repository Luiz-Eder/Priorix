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
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O e-mail não pode estar vazio.");

            var user = _userRepository.GetUserByEmail(email);

            if (user == null)
                throw new KeyNotFoundException("Usuário não encontrado com o e-mail informado.");

            return user;
        }

        public User FindById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.");

            var user = _userRepository.FindById(id);

            if (user == null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            return user;
        }

        public void AddUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "Os dados do usuário são obrigatórios.");

            if (string.IsNullOrWhiteSpace(user.Name))
                throw new ArgumentException("O nome do usuário é obrigatório.");

            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("O e-mail do usuário é obrigatório.");

            if (!user.Email.Contains("@") || !user.Email.Contains("."))
                throw new ArgumentException("O e-mail informado é inválido.");

            var existingUser = _userRepository.GetUserByEmail(user.Email);
            if (existingUser != null)
                throw new InvalidOperationException("Já existe um usuário cadastrado com este e-mail.");

            _userRepository.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (user.Id <= 0)
                throw new ArgumentException("ID de usuário inválido.");

            if (!_userRepository.UserExists(user.Id))
                throw new KeyNotFoundException("Usuário não encontrado.");

            if (string.IsNullOrWhiteSpace(user.Name))
                throw new ArgumentException("O nome do usuário é obrigatório.");

            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("O e-mail do usuário é obrigatório.");

            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.");

            if (!_userRepository.UserExists(id))
                throw new KeyNotFoundException("Usuário não encontrado para exclusão.");

            _userRepository.DeleteUser(id);
        }

        public bool UserExists(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.");

            return _userRepository.UserExists(id);
        }
    }
}
