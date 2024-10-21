
using Data.Entities;
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserServices
    {
        User CreateUser(UserGlobalDTO userDto);
        List<UserDto> GetUsers();
        User? AuthenticateUser(string username, string password);


    }
}
