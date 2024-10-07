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
        public User CreateUser(UserDto userDto)
        {
            // Crear un nuevo usuario
            var user = new User
            {
                Id = userDto.Id,
                Username = userDto.username,
                Password = userDto.password// En una aplicación real, cifrar la contraseña
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

        
    }
    }
