using OnlineRetailShopping.Repository.Entities;
using OnlineRetailShopping.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Repository.Implementations
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly CombineContext _context;
        public AuthorizationRepository(CombineContext context)
        {
            _context = context;
        }
        public async Task<User> Role(int userId)
        {
            User user = null;
            user = _context.Users.Find(userId);
            return user;
        }
    }
}
