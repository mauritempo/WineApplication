using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public class UserRepository
    {
        private readonly List<User> _users = new List<User>();

        public void AddUser(User user)
        {
            _users.Add(user);
        }
        public List<User> GetUsers() // Método para obtener todos los vinos
        {
            return _users;
        }
    }
}
