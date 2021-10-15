using MyLibraryWebApi.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryWebApi.Models.Repository
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public User Get(string id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
        }
    }
}
