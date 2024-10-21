using Data.Entities;
using Data.Repo;
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserServices : IUserServices
    {
        private readonly UserRepository _userRepository;

        public UserServices(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User CreateUser(UserGlobalDTO userDto)
        {
            // Crear un nuevo usuario
            var user = new User
            {
                
                Username = userDto.Username,
                Password = userDto.Password// En una aplicación real, cifrar la contraseña
            };

            _userRepository.AddUser(user);
            return user;
        }

        
        public List<UserDto> GetUsers()
        {
            var user = _userRepository.GetUsers(); // Llamada al repositorio

            
            return user.Select(w => new UserDto
            {
                username = w.Username,
                Id = w.Id,

            }).ToList();
        }
        public User? AuthenticateUser(string username, string password)
        {
            User? userToReturn = _userRepository.Get(username);
            if (userToReturn is not null && userToReturn.Password == password)
                return userToReturn;
            return null;
        }

    }
    }
