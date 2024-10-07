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
        private readonly WineContext _context;
        public UserRepository(WineContext context) 
        { 
            _context = context; 
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }
        public List<User> GetUsers() // Método para obtener todos los vinos
        {
            return _context.Users.ToList();
        }
    }
}
